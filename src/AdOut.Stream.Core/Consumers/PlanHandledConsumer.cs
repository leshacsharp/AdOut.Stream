using AdOut.Extensions.Communication;
using AdOut.Stream.Model.Events;
using AdOut.Stream.Model.Interfaces;
using AdOut.Stream.Model.Models;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace AdOut.Stream.Core.Consumers
{
    public class PlanHandledConsumer : BaseConsumer<PlanHandledEvent>, IPlanHandledConsumer
    {
        //todo: it's the scoped service
        private readonly ITimeLineService _timeLineService;
        private readonly ITimeLineScheduler _timeLineScheduler;
        private readonly IMapper _mapper;

        public PlanHandledConsumer(
            ITimeLineService timeLineService,
            ITimeLineScheduler timeLineScheduler,
            IMapper mapper)
        {
            _timeLineService = timeLineService;
            _timeLineScheduler = timeLineScheduler;
            _mapper = mapper;
        }

        protected override Task HandleAsync(PlanHandledEvent deliveredEvent)
        {
            var playPlanToday = deliveredEvent.Schedules.Any(s => s.Dates.Contains(DateTime.Now.Date));
            if (!playPlanToday || deliveredEvent.CreatedDateUtc.ToLocalTime().Date != DateTime.Now.Date)          
            {
                return Task.CompletedTask;
            }

            var newPlan = _mapper.Map<PlanTime>(deliveredEvent);
            var currentTimeLine = _timeLineScheduler.RemainTimeBlocks;

            if (currentTimeLine.Any() || _timeLineScheduler.Current != null)
            {
                var timeLineStart = _timeLineScheduler.Current != null
                    ? _timeLineScheduler.Current.Gap ? DateTime.Now.TimeOfDay : _timeLineScheduler.Current.End
                    : currentTimeLine.First().Start;

                var updatedTimeLine = _timeLineService.MergeTimeLine(currentTimeLine, newPlan, DateTime.Now.Date, timeLineStart);
                _timeLineScheduler.Configure(updatedTimeLine, true);
            }

            return Task.CompletedTask;
        }
    }
}
