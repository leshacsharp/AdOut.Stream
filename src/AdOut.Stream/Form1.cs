using AdOut.Stream.Model.Interfaces;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        //private readonly IAdQueueService _adQueueService;
        //public Form1(IAdQueueService adQueueService)
        //{
        //    _adQueueService = adQueueService;
        //}

        public Form1()
        {
            LibVLCSharp.Shared.Core.Initialize();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var timeBlock = _adQueueService.Dequeue();
            //if (timeBlock != null && timeBlock.Start > DateTime.Now.TimeOfDay)
            //{
            //    var waitForStart = timeBlock.Start - DateTime.Now.TimeOfDay;
            //    await Task.Delay(waitForStart);
            //}
            var _libVLC = new LibVLC();
            var _mp = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mp;
            _mp.Play(new Media(_libVLC, new Uri("https://s3.eu-central-1.amazonaws.com/adout.planning/bird")));
        }
    }
}
