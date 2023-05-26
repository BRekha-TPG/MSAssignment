using MassTransit;
using Microsoft.Extensions.Logging;
using NotificationContracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Consumers
{
    internal class ActivateCustomerConsumer : IConsumer<IActivateCustomer>
    {
        private readonly ILogger<ActivateCustomerConsumer> _logger;

        public ActivateCustomerConsumer(ILogger<ActivateCustomerConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<IActivateCustomer> context)
        {
            _logger.LogInformation($"Customer Activated Id : {context.Message.CustomerId}");
            _logger.LogInformation($"Customer Activated Name :  {context.Message.CustomerName}");
        }
    }
}
