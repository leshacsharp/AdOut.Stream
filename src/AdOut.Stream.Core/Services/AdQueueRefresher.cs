using AdOut.Stream.Model.Interfaces;
using AdOut.Stream.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AdOut.Stream.Core.Services
{
    public class AdQueueRefresher : IAdQueueRefresher, IDisposable
    {
        private readonly ITimeLineService _timeLineService;
        private readonly IAdQueueService _adQueueService;
        private Timer _timer;

        public AdQueueRefresher(
            ITimeLineService timeLineService,
            IAdQueueService adQueueService)
        {
            _timeLineService = timeLineService;
            _adQueueService = adQueueService;
        }

        //todo: refactor operations that are related with time
        public void Start()
        {
            ExecuteAsync(null);

            var waitForNextDay = TimeSpan.FromDays(1) - DateTime.Now.TimeOfDay;
            _timer = new Timer(ExecuteAsync, null, waitForNextDay, TimeSpan.FromDays(1));
        }

        private void ExecuteAsync(object state)
        {
            //todo: fetch plans from the AdOut.Planning service
            List<PlanTime> plans = null;
            var timeLine = _timeLineService.GenerateTimeLine(plans, DateTime.Now.Date);
            _adQueueService.Configure(timeLine);   
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
