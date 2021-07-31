using AdOut.Stream.Core.Helpers;
using AdOut.Stream.Model.Interfaces;
using AdOut.Stream.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdOut.Stream.Core.Services
{
    //probably singletone
    public class TimeLineScheduler : ITimeLineScheduler, IDisposable
    {
        private Queue<TimeBlock> _queue = new Queue<TimeBlock>();
        private Timer _timer;
        private TimeBlock _currentTimeBlock;
        private bool _isStarted;

        public event EventHandler<TimeBlockChangedEventArgs> TimeBlockChanged;
        public event EventHandler TimeLimeEnded;
        public TimeBlock Current => _currentTimeBlock;
        public List<TimeBlock> RemainTimeBlocks => _queue.ToList();

        public void Configure(IEnumerable<TimeBlock> timeLine, bool modifyTimeLine = false)
        {
            if (modifyTimeLine)
            {
                var firstTimeBlock = timeLine.FirstOrDefault();
                if (firstTimeBlock != null && _currentTimeBlock != null && _currentTimeBlock.Gap)
                {
                    _currentTimeBlock = firstTimeBlock;
                    TimeBlockChanged.Invoke(this, new TimeBlockChangedEventArgs(_currentTimeBlock));
                }
            }
            _queue = new Queue<TimeBlock>(timeLine);
        }

        public void Start()
        {
            if (_queue.TryPeek(out var firstTimeBlock))
            {
                var waitForStart = firstTimeBlock.Start - DateTime.Now.TimeOfDay;
                if (waitForStart < TimeSpan.Zero)
                {
                    waitForStart = TimeSpan.Zero;
                }
                _timer = new Timer(ChangeTimeBlocks, null, waitForStart, TimeSpan.FromSeconds(1));
            }    
        }

        private void ChangeTimeBlocks(object state)
        {
            if (!_isStarted && _queue.TryDequeue(out _currentTimeBlock))
            {
                TimeBlockChanged(this, new TimeBlockChangedEventArgs(_currentTimeBlock));
                _isStarted = true;
                return;
            }

            if (_currentTimeBlock.End.TrimMilliseconds() == DateTime.Now.TimeOfDay.TrimMilliseconds())
            {
                if (_queue.TryDequeue(out _currentTimeBlock))
                {
                    TimeBlockChanged(this, new TimeBlockChangedEventArgs(_currentTimeBlock));
                }
                else
                {              
                    TimeLimeEnded(this, EventArgs.Empty);
                    _currentTimeBlock = null;
                    _timer.Dispose();
                }
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
