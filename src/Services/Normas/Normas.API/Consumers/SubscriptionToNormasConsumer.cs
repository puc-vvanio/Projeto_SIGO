using MassTransit;
using SIGO.Normas.API.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Normas.API.Consumers
{
    public class SubscriptionToNormasConsumer : IConsumer<SubscribeToNormasCommand>
    {
        public Task Consume(ConsumeContext<SubscribeToNormasCommand> context)
        {
            Debug.WriteLine("Subscribed successfully");
            return Task.CompletedTask;
        }
    }
}
