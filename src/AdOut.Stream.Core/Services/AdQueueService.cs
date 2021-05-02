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

        public event EventHandler CurrentBlockShouldBeChanged;

        public TimeBlock Dequeue()
        {
            _queue.TryDequeue(out _currentTimeBlock);
            return _currentTimeBlock;
        }

        public void Configure(IEnumerable<TimeBlock> timeLine, bool modifyTimeLine = false)
        {
            if (modifyTimeLine)
            {
                var firstTimeBlock = timeLine.FirstOrDefault();
                if (firstTimeBlock != null && Current != null && Current.Gap)
                {
                    CurrentBlockShouldBeChanged.Invoke(this, new EventArgs());
                }
            }

            _queue = new Queue<TimeBlock>(timeLine);
        }
    }
}
