using MassTransit;
using SIGO.ProcessoIndustrial.API.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.API.Consumers
{
    public class SubscriptionSuccessfulConsumer : IConsumer<SubscriptionSuccessfulEvent>
    {
        public Task Consume(ConsumeContext<SubscriptionSuccessfulEvent> context)
        {
            Debug.WriteLine("Subscribed successfully");
            return Task.CompletedTask;
        }
    }
}
