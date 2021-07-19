using System;

namespace AdOut.Stream.Model.Models
{
    public class TimeBlock
    {
        public TimeBlock(string title, string path, ContentType type, TimeSpan start, TimeSpan end, bool gap = false)
        {
            Title = title;
            Path = path;
            ContentType = type;
            Start = start;
            End = end;
            Gap = gap;
        }

        public string Title { get; set; }
        public string Path { get; set; }
        public ContentType ContentType { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Duration => End - Start;
        public bool Gap { get; set; }
    }
}
