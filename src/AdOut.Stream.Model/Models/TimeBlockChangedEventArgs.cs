using System;

namespace AdOut.Stream.Model.Models
{
    public class TimeBlockChangedEventArgs : EventArgs
    {
        public TimeBlockChangedEventArgs(TimeBlock timeBlock)
        {
            TimeBlock = timeBlock;
        }
        public TimeBlock TimeBlock { get; set; }
    }
}
