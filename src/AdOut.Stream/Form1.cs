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
        private readonly IAdQueueService _adQueueService;
        private readonly LibVLC _libVLC;
        private readonly MediaPlayer _player;

        private bool _nextRestOfMedia;
        
        //public Form1(IAdQueueService adQueueService)
        //{
        //    _adQueueService = adQueueService;
        //}

        public Form1()
        {
            InitializeComponent();
            LibVLCSharp.Shared.Core.Initialize();
            _libVLC = new LibVLC();
            _player = new MediaPlayer(_libVLC);
            _player.EndReached += _player_EndReached;
            videoView1.MediaPlayer = _player;
            _adQueueService = new AdQueueService();

            var timeBlock = new TimeBlock("test", "https://s3.eu-central-1.amazonaws.com/adout.planning/bird", ContentType.Video, DateTime.Now.TimeOfDay, DateTime.Now.TimeOfDay.Add(TimeSpan.FromSeconds(11)));
            var timeBlock2 = new TimeBlock("test", "https://file-examples-com.github.io/uploads/2017/04/file_example_MP4_640_3MG.mp4", ContentType.Video, DateTime.Now.TimeOfDay, DateTime.Now.TimeOfDay.Add(TimeSpan.FromSeconds(5)));
            _adQueueService.Configure(new List<TimeBlock>() { timeBlock, timeBlock2 });
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var firstTimeBlock = _adQueueService.Dequeue();
            if (firstTimeBlock != null && firstTimeBlock.Start > DateTime.Now.TimeOfDay)
            {
                var waitForStart = firstTimeBlock.Start - DateTime.Now.TimeOfDay;
                await Task.Delay(waitForStart);
            }

            await PlayTimeBlockAsync(firstTimeBlock);   
        }

        private void _player_EndReached(object sender, EventArgs e)
        {
            //https://github.com/ZeBobo5/Vlc.DotNet/wiki/Vlc.DotNet-freezes-(don't-call-Vlc.DotNet-from-a-Vlc.DotNet-callback)
            Task.Run(async () =>
            {
                if (_nextRestOfMedia)
                {
                    var restMedia = _player.Media;
                    var mediaOptions = CalculateMediaOptions(_adQueueService.Current, restMedia);
                    restMedia.AddOption($":input-repeat=0");
                    restMedia.AddOption($":run-time={mediaOptions.restTime}");

                    _player.Play(restMedia);
                    _nextRestOfMedia = false;
                }
                else
                {
                    var nextTimeBlock = _adQueueService.Dequeue();
                    await PlayTimeBlockAsync(nextTimeBlock);
                }
            });
        }

        private async Task PlayTimeBlockAsync(TimeBlock timeBlock)
        {
            var media = new Media(_libVLC, new Uri(timeBlock.Path));
            var parseStatus = await media.Parse(MediaParseOptions.ParseNetwork);

            //todo: think about handlers (mb wait)
            if (parseStatus == MediaParsedStatus.Done)
            {
                var mediaOptions = CalculateMediaOptions(timeBlock, media);
                if (mediaOptions.fullRepeatTimes > 0)
                {
                    media.AddOption($":input-repeat={mediaOptions.fullRepeatTimes - 1}");
                    _nextRestOfMedia = mediaOptions.restTime > 0;
                }
                else
                {
                    media.AddOption($":run-time={mediaOptions.restTime}");
                }

                _player.Play(media);
            }
        }

        private (decimal fullRepeatTimes, decimal restTime) CalculateMediaOptions(TimeBlock timeBlock, Media media)
        {
            var mediaDuration = TimeSpan.FromMilliseconds(media.Duration);
            var mediaRepeatTimes = (decimal)(timeBlock.Duration / mediaDuration);
            var fullRepeatTimes = Math.Floor(mediaRepeatTimes);
            var restTimeRate = mediaRepeatTimes - fullRepeatTimes;
            var restTime = restTimeRate * (decimal)mediaDuration.TotalSeconds;
            var roundRestTime = Math.Round(restTime, 1, MidpointRounding.AwayFromZero);

            return (fullRepeatTimes, roundRestTime);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _libVLC.Dispose();
            _player.Dispose();
        }
    }
}
