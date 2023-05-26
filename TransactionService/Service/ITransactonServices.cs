using TransactionService.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TransactionService.Service
{
    public interface ITransactonServices
    {
        Task<IEnumerable<AccountInformation>> GetAllAccountInfo();
        Task<AccountInformation> CheckBalance(string AccountNumber);
        Task<AccountInformation> Deposite(string account, decimal amount);

        Task<AccountInformation> Withdraw(string account, decimal amount);

        Task<IEnumerable<AccountInformation>> FundTransfer(string SourceAcc, string desAcc, decimal amount);
    }
}
