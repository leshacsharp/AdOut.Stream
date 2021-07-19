using AdOut.Extensions.Communication.Interfaces;
using AdOut.Extensions.Communication.Models;
using AdOut.Extensions.Infrastructure;
using AdOut.Stream.Model.Config;
using AdOut.Stream.Model.Events;
using AdOut.Stream.Model.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdOut.Stream.Core.Services
{
    public class PlanHandledQueueInitialization : IInitialization
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IMessageBrokerHelper _messageBrokerHelper; 
        private readonly IPlanHandledConsumer _planHandledConsumer;
        private readonly AdPointConfig _config;

        public PlanHandledQueueInitialization(
            IMessageBroker messageBroker,
            IMessageBrokerHelper messageBrokerHelper,
            IPlanHandledConsumer planHandledConsumer,
            IOptions<AdPointConfig> config)
        {
            _messageBroker = messageBroker;
            _messageBrokerHelper = messageBrokerHelper;
            _planHandledConsumer = planHandledConsumer;
            _config = config.Value;
        }

        public Task InitAsync()
        {
            var queueName = $"adpoint-{_config.Id}-queue";
            var queueBinding = new Dictionary<string, object>()
            {
                { DefaultHeaders.XMatch, "any" },
                { $"adpoint-{_config.Id}", true }
            };

            var exchangeName = _messageBrokerHelper.GetExchangeName(typeof(PlanHandledEvent));
            _messageBroker.CreateExchange(exchangeName, Extensions.Communication.ExchangeTypeEnum.Headers);
            _messageBroker.CreateQueue(queueName, exchangeName, arguments: queueBinding);
            _messageBroker.Subscribe(queueName, _planHandledConsumer);

            return Task.CompletedTask;
        }
    }
}
