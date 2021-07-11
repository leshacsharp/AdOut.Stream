using AdOut.Extensions.Communication.Interfaces;
using AdOut.Extensions.Communication.Models;
using AdOut.Extensions.Infrastructure;
using AdOut.Stream.Model.Events;
using AdOut.Stream.Model.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdOut.Stream.Core.Services
{
    public class PlanHandledQueueInitialization : IInitialization
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IMessageBrokerHelper _messageBrokerHelper; 
        private readonly IPlanHandledConsumer _planHandledConsumer;
        private readonly IConfiguration _configuration;

        public PlanHandledQueueInitialization(
            IMessageBroker messageBroker,
            IMessageBrokerHelper messageBrokerHelper,
            IPlanHandledConsumer planHandledConsumer,
            IConfiguration configuration)
        {
            _messageBroker = messageBroker;
            _messageBrokerHelper = messageBrokerHelper;
            _planHandledConsumer = planHandledConsumer;
            _configuration = configuration;
        }

        public Task InitAsync()
        {
            var adPointId = _configuration.GetValue<string>("AdPointId");
            var queueName = $"adpoint-{adPointId}-queue";
            var queueBinding = new Dictionary<string, object>()
            {
                { DefaultHeaders.XMatch, "any" },
                { $"adpoint-{adPointId}", true }
            };

            var exchangeName = _messageBrokerHelper.GetExchangeName(typeof(PlanHandledEvent));
            _messageBroker.CreateExchange(exchangeName, Extensions.Communication.ExchangeTypeEnum.Headers);
            _messageBroker.CreateQueue(queueName, exchangeName, arguments: queueBinding);
            _messageBroker.Subscribe(queueName, _planHandledConsumer);

            return Task.CompletedTask;
        }
    }
}
