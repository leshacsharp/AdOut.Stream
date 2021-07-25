using AdOut.Stream.Model.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdOut.Stream.Core.Services
{
    public class AdQueueRefresher : IAdQueueRefresher, IDisposable
    {
        private readonly ITimeLineService _timeLineService;
        private readonly ITimeLineScheduler _timeLineScheduler;
        private readonly IPlanService _planService;
        private Timer _timer;

        public AdQueueRefresher(
            ITimeLineService timeLineService,
            ITimeLineScheduler timeLineScheduler,
            IPlanService planService)
        {
            _timeLineService = timeLineService;
            _timeLineScheduler = timeLineScheduler;
            _planService = planService;
        }

        public async Task StartAsync()
        {
            await SetTimeLineAsync();

            var waitForNextDay = TimeSpan.FromDays(1) - DateTime.Now.TimeOfDay;
            _timer = new Timer(async (o) => await SetTimeLineAsync(), null, waitForNextDay, TimeSpan.FromDays(1));
        }

        private async Task SetTimeLineAsync()
        {
            var plans = await _planService.GetPlanTimesAsync(DateTime.Now);
            var timeLine = _timeLineService.GenerateTimeLine(plans, DateTime.Now.Date);
            _timeLineScheduler.Configure(timeLine);   
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
