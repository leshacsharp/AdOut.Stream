using AdOut.Stream.Model.Models;
using System;
using System.Collections.Generic;

namespace AdOut.Stream.Model.Interfaces
{
    public interface ITimeLineScheduler
    {  
        void Configure(IEnumerable<TimeBlock> timeLine, bool modifyTimeLine = false);
        void Start();
        event EventHandler<TimeBlockChangedEventArgs> TimeBlockChanged;
        event EventHandler TimeLimeEnded;
        TimeBlock Current { get; }
        List<TimeBlock> RemainTimeBlocks { get; }
    }
}
 