using System;

namespace AdOut.Stream.Model.Models
{
    public class TimeRange
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public bool IsInterescted(TimeRange timeRange)
        {
            return this.Start < timeRange.End && timeRange.Start < this.End;
        }

        public bool IsInterescted(TimeSpan start, TimeSpan end)
        {
            return this.Start < end && start < this.End;
        }
    }
}
