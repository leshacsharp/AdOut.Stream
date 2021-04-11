using AdOut.Stream.Model.Models;
using System;
using System.Collections.Generic;

namespace AdOut.Stream.Model.Interfaces
{
    public interface IAdQueueService
    {
        TimeBlock Current { get; }
        List<TimeBlock> RemainTimeBlocks { get; }

        event EventHandler<TimeBlock> CurrentModified;
        TimeBlock Dequeue();
        void Configure(IEnumerable<TimeBlock> timeLine);
    }
}
 