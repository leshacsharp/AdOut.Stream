using AdOut.Extensions.Communication;
using AdOut.Stream.Model.Events;
using AdOut.Stream.Model.Interfaces;
using AdOut.Stream.Model.Models;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace AdOut.Stream.Core.Consumers
{
    public class PlanHandledConsumer : BaseConsumer<PlanHandledEvent>, IPlanHandledConsumer
    {
        private readonly ITimeLineService _timeLineService;
        private readonly IAdQueueService _adQueueService;
        private readonly IMapper _mapper;

        public PlanHandledConsumer(
            ITimeLineService timeLineService,
            IAdQueueService adQueueService,
            IMapper mapper)
        {
            _timeLineService = timeLineService;
            _adQueueService = adQueueService;
            _mapper = mapper;
        }

        //todo: refactor operations that are related with time
        protected override Task HandleAsync(PlanHandledEvent deliveredEvent)
        {
            //todo: refuse the event if the plan won't be played today
            if (deliveredEvent.StartDateTime.Date != DateTime.Now.Date ||
                deliveredEvent.CreatedDateUtc.Date != DateTime.Now.Date)
            {
                return Task.CompletedTask;
            }

            //todo: change time getters
            var newPlan = _mapper.Map<PlanTime>(deliveredEvent);
            var currentTimeLine = _adQueueService.RemainTimeBlocks;
            var timeLineStart = _adQueueService.Current.Gap ? DateTime.Now.TimeOfDay : _adQueueService.Current.End;
            var updatedTimeLine = _timeLineService.MergeTimeLine(currentTimeLine, newPlan, DateTime.Now.Date, timeLineStart);

            _adQueueService.Configure(updatedTimeLine, true);
            return Task.CompletedTask;
        }
    }
}
