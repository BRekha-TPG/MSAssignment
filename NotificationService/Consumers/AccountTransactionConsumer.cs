using MassTransit;
using Microsoft.Extensions.Logging;
using NotificationContracts.DataContracts;

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
