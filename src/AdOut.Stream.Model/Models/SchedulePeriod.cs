using AdOut.Stream.Model.Classes;
using System;
using System.Collections.Generic;

namespace AdOut.Stream.Model.Models
{
    public class SchedulePeriod
    {
        public List<TimeRange> TimeRanges { get; set; }

        public List<DateTime> Dates { get; set; }
    }
}
