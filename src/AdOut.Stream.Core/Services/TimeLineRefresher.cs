using AdOut.Stream.Model.Config;
using AdOut.Stream.Model.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdOut.Stream.Core.Services
{
    public class TimeLineRefresher : ITimeLineRefresher, IDisposable
    {
        private readonly ITimeLineService _timeLineService;
        private readonly ITimeLineScheduler _timeLineScheduler;
        private readonly IPlanService _planService;
        private readonly AdPointConfig _config;
        private Timer _timer;

        public TimeLineRefresher(
            ITimeLineService timeLineService,
            ITimeLineScheduler timeLineScheduler,
            IPlanService planService,
            IOptions<AdPointConfig> options)
        {
            _timeLineService = timeLineService;
            _timeLineScheduler = timeLineScheduler;
            _planService = planService;
            _config = options.Value;
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
            var startTimeLine = DateTime.Now.TimeOfDay > _config.StartWorking ? DateTime.Now.TimeOfDay : _config.StartWorking;
            var timeLine = _timeLineService.GenerateTimeLine(plans, DateTime.Now.Date, startTimeLine);
            _timeLineScheduler.Configure(timeLine);   
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
