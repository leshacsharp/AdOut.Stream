using AdOut.Stream.Model.Models;
using System;
using System.Collections.Generic;

namespace AdOut.Stream.Model.Interfaces
{
    public interface IAdQueueService
    {
        TimeBlock Current { get; }
        List<TimeBlock> RemainTimeBlocks { get; }

        event EventHandler CurrentShouldBeChanged;
        TimeBlock Dequeue();
        void Configure(IEnumerable<TimeBlock> timeLine, bool modifyTimeLine = false);
    }
}
 