using System;

namespace AdOut.Stream.Model.Models
{
    public class TimeAdBlock
    {
        public TimeAdBlock(string title, string path, TimeSpan start, TimeSpan end, bool gap = false)
        {
            Title = title;
            Path = path;
            Start = start;
            End = end;
            Gap = gap;
        }

        public string Title { get; set; }

        public string Path { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public TimeSpan Duration => End - Start;

        public bool Gap { get; set; }
    }
}
