using AdOut.Stream.Core.Services;
using AdOut.Stream.Model.Interfaces;
using AdOut.Stream.Model.Models;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdOut.Stream
{
    public partial class Form1 : Form
    {
        private ITimeLineScheduler _timeLineScheduler;
        private LibVLC _libVLC;
        private MediaPlayer _player;
        
        //public Form1(IAdQueueService adQueueService)
        //{
        //    _adQueueService = adQueueService;
        //}

        public Form1()
        {
            InitializeComponent();
            LibVLCSharp.Shared.Core.Initialize();       
        }

        private void Form1_Load(object sender, EventArgs e)
        {         
            _libVLC = new LibVLC();
            _player = new MediaPlayer(_libVLC);
            //todo: handle network issues
           // _player.EndReached += _player_EndReached;
            videoView1.MediaPlayer = _player;

            var s1 = DateTime.Now.TimeOfDay;
            var s2 = s1.Add(TimeSpan.FromSeconds(12));
            var s3 = s2;
            var s4 = s3.Add(TimeSpan.FromSeconds(5));

            _timeLineScheduler = new TimeLineScheduler();
            _timeLineScheduler.TimeBlockChanged += TimeLineScheduler_TimeBlockChanged;
            _timeLineScheduler.TimeLimeEnded += TimeLineScheduler_TimeLimeEnded;

            var timeBlock = new TimeBlock("test", "https://s3.eu-central-1.amazonaws.com/adout.planning/bird", ContentType.Video, s1, s2);
            var timeBlock2 = new TimeBlock("test2", "https://file-examples-com.github.io/uploads/2017/04/file_example_MP4_640_3MG.mp4", ContentType.Video, s3, s4);
            _timeLineScheduler.Configure(new List<TimeBlock>() { timeBlock, timeBlock2 });
            _timeLineScheduler.Start();
        }
  
        private async void TimeLineScheduler_TimeBlockChanged(object sender, TimeBlockChangedEventArgs e)
        {
            var media = new Media(_libVLC, new Uri(e.TimeBlock.Path));
            var parseStatus = await media.Parse(MediaParseOptions.ParseNetwork);

            if (parseStatus != MediaParsedStatus.Done)
            {
                //todo: handle network issues
                return;
            }

            var mediaDuration = TimeSpan.FromMilliseconds(media.Duration);
            var mediaRepeatTimes = (decimal)(e.TimeBlock.Duration / mediaDuration);
            var repeatTimes = Math.Ceiling(mediaRepeatTimes);
            if (repeatTimes > 1)
            {
                media.AddOption($":input-repeat={repeatTimes - 1}");
            }
            _player.Play(media);
        }

        private void TimeLineScheduler_TimeLimeEnded(object sender, EventArgs e)
        {
            _player.Stop();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _libVLC.Dispose();
            _player.Dispose();
        }
    }
}
