using MassTransit;
using NotificationContracts.DataContracts;
using TransactionService.Service;

namespace TransactionService.Consumer
{
    public class NewCustomerConsumerT : IConsumer<INewCustomerT>
    {
        private readonly ILogger<NewCustomerConsumerT> _logger;
        private readonly ITransactonServices _transactonServices;

        public NewCustomerConsumerT(ILogger<NewCustomerConsumerT> logger, ITransactonServices transactonServices)
        {
            _logger = logger;
            _transactonServices = transactonServices;
        }

        public async Task Consume(ConsumeContext<INewCustomerT> context)
        {
            _transactonServices.CreateNewCustomer(context.Message);
        }

    }
}