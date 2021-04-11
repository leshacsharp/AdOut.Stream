using AdOut.Stream.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdOut.Stream
{
    public partial class Form1 : Form
    {
        private readonly IAdQueueService _adQueueService;
        public Form1(IAdQueueService adQueueService)
        {
            _adQueueService = adQueueService;
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
