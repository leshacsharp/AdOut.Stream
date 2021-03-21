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
            return Task.CompletedTask;
        }
    }
}
