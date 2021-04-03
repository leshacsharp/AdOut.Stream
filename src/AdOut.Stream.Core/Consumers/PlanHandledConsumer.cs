using AdOut.Extensions.Communication;
using AdOut.Stream.Model.Events;
using AdOut.Stream.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdOut.Stream.Core.Consumers
{
    public class PlanHandledConsumer : BaseConsumer<PlanHandledEvent>, IPlanHandledConsumer
    {
        protected override Task HandleAsync(PlanHandledEvent deliveredEvent)
        {
            //todo: refuse the event if the plan won't be played today
            //todo: check time on corectness (utc or not)
            if (deliveredEvent.StartDateTime.Date != DateTime.Now.Date)
            {
                return Task.CompletedTask;
            }


            return Task.CompletedTask;
        }
    }
}
