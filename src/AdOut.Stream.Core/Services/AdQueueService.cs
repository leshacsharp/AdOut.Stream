using AdOut.Stream.Model.Interfaces;
using AdOut.Stream.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdOut.Stream.Core.Services
{
    //probably singletone
    public class AdQueueService : IAdQueueService
    {
        private Queue<TimeBlock> _queue = new Queue<TimeBlock>();
        private TimeBlock _currentTimeBlock;

        public TimeBlock Current => _currentTimeBlock;
        public List<TimeBlock> RemainTimeBlocks => _queue.ToList();

        public event EventHandler<TimeBlock> CurrentModified;

        public TimeBlock Dequeue()
        {
            _currentTimeBlock = _queue.Dequeue();
            return _currentTimeBlock;
        }

        public void Configure(IEnumerable<TimeBlock> timeLine)
        {
            var curTimeRange = new TimeRange() { Start = Current.Start, End = Current.End };
            var firstTimeBlock = timeLine.FirstOrDefault();

            if (firstTimeBlock != null &&
                firstTimeBlock.Gap &&
                curTimeRange.IsInterescted(firstTimeBlock.Start, firstTimeBlock.End))
            {
                CurrentModified.Invoke(this, firstTimeBlock);
            }

            _queue = new Queue<TimeBlock>(timeLine);
        }
    }
}
