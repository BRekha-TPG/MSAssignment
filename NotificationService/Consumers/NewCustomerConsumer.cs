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
    internal class NewCustomerConsumer : IConsumer<INewCustomer>
    {
        private readonly ILogger<NewCustomerConsumer> _logger;

        public NewCustomerConsumer(ILogger<NewCustomerConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<INewCustomer> context)
        {
            _logger.LogInformation($"New Customer Registered Id : {context.Message.CustomerId}, Name : {context.Message.CustomerName}");

        }

    }
}
