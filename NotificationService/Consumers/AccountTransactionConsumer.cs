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
    public class AccountTransactionConsumer : IConsumer<IAccountTransaction>
    {
        private readonly ILogger<AccountTransactionConsumer> _logger;

        public AccountTransactionConsumer(ILogger<AccountTransactionConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<IAccountTransaction> context)
        {
            _logger.LogInformation($"Account Transaction on AccountNo : {context.Message.FromAccount}");
            _logger.LogInformation($"Transaction Type : {context.Message.TransactionType}");
            _logger.LogInformation($"Current Balance : {context.Message.CurrentBalance}");
            // throw new NotImplementedException();
        }
    }
}
