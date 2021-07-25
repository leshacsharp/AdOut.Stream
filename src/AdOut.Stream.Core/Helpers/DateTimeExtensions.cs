using System;

namespace AdOut.Stream.Core.Helpers
{
    public static class DateTimeExtensions
    {
        public static TimeSpan TrimMilliseconds(this TimeSpan ts)
        {
            return new TimeSpan(ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
        }
    }
}
