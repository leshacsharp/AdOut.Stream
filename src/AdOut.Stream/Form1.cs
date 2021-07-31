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
using System.Net.NetworkInformation;
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

        //public Form1(ITimeLineScheduler timeLineScheduler)
        //{
        //    _timeLineScheduler = timeLineScheduler;
        //}

        public Form1()
        {
            InitializeComponent();
            LibVLCSharp.Shared.Core.Initialize();       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;

            _libVLC = new LibVLC();
            _player = new MediaPlayer(_libVLC);    
            _player.Playing += _player_Playing;
            videoView1.MediaPlayer = _player;

            var s1 = DateTime.Now.TimeOfDay;
            var s2 = s1.Add(TimeSpan.FromSeconds(15));
            var s3 = s2;
            var s4 = s3.Add(TimeSpan.FromSeconds(20));

            _timeLineScheduler = new TimeLineScheduler();
            _timeLineScheduler.TimeBlockChanged += TimeLineScheduler_TimeBlockChanged;
            _timeLineScheduler.TimeLimeEnded += TimeLineScheduler_TimeLimeEnded;

            var timeBlock = new TimeBlock("test", "https://s3.eu-central-1.amazonaws.com/adout.planning/bird", ContentType.Video, s1, s2);
            var timeBlock2 = new TimeBlock("test2", "https://file-examples-com.github.io/uploads/2017/04/file_example_MP4_640_3MG.mp4", ContentType.Video, s3, s4);

            var timeBlock3 = new TimeBlock("test3", "https://file-examples-com.github.io/uploads/2017/04/file_example_MP4_640_3MG.mp4", ContentType.Video, DateTime.Now.TimeOfDay, DateTime.Now.TimeOfDay.Add(TimeSpan.FromSeconds(30)));

            var timeblock4 = new TimeBlock("test4", "https://images.pexels.com/photos/2629233/pexels-photo-2629233.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260", ContentType.Image, s1, s2);
            var timeblock5 = new TimeBlock("test5", "https://images.pexels.com/photos/3614316/pexels-photo-3614316.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260", ContentType.Image, s3, s4);

            //_timeLineScheduler.Configure(new List<TimeBlock>() { timeBlock, timeBlock2 });
            //_timeLineScheduler.Configure(new List<TimeBlock>() { timeBlock3 });
            _timeLineScheduler.Configure(new List<TimeBlock>() { timeblock4, timeblock5 });
            _timeLineScheduler.Start();     
        }

        private async Task PlayTimeBlockAsync(TimeBlock timeBlock)
        {
            var media = new Media(_libVLC, new Uri(timeBlock.Path));
            var parseStatus = await media.Parse(MediaParseOptions.ParseNetwork);

            if (parseStatus == MediaParsedStatus.Done)
            {
                var mediaDuration = TimeSpan.FromMilliseconds(media.Duration);
                var mediaRepeatTimes = (decimal)(timeBlock.Duration / mediaDuration);
                var repeatTimes = Math.Ceiling(mediaRepeatTimes);
                if (repeatTimes > 1)
                {
                    media.AddOption($":input-repeat={repeatTimes - 1}");
                }
                _player.Play(media);
            }
        }

        private async void TimeLineScheduler_TimeBlockChanged(object sender, TimeBlockChangedEventArgs e)
        {
            Debug.WriteLine($"{DateTime.Now} - TimeLineScheduler_TimeBlockChanged - {e.TimeBlock.Title}");
            await PlayTimeBlockAsync(e.TimeBlock);
        }

        private async void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            Debug.WriteLine($"{DateTime.Now} - NetworkAvailabilityChanged - IsAvailable:{e.IsAvailable}");

            if (e.IsAvailable && _timeLineScheduler.Current != null)
            {
                await PlayTimeBlockAsync(_timeLineScheduler.Current);
            }
            else
            {
                //todo: do something like sending email about disconecting the network connection
            }
        }

        private void TimeLineScheduler_TimeLimeEnded(object sender, EventArgs e)
        {
            _player.Stop();
            Debug.WriteLine($"{DateTime.Now} - TimeLimeEnded");
        }

        private void _player_Playing(object sender, EventArgs e)
        {
            Debug.WriteLine($"{DateTime.Now} - Playing");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _libVLC.Dispose();
            _player.Dispose();
        }
    }
}
