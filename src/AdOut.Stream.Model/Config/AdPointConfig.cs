using System;

namespace AdOut.Stream.Model.Config
{
    public class AdPointConfig
    {
        public string DefaultAdTitle { get; set; }

        public string DefaultAdPath { get; set; }

        public TimeSpan StartWorking { get; set; }

        public TimeSpan EndWorking { get; set; }
    }
}
