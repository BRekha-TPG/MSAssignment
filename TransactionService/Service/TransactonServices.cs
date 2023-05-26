using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using System.Data;
using System.Linq;
using TransactionService.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TransactionService.Service
{
    public class TransactonServices : ITransactonServices
    {
       // string ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TransactionDB;Integrated Security=SSPI;Encrypt=false";
        private readonly AccountDbContext _context;
        private readonly IConfiguration _configuration;

        public TransactonServices(AccountDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration; 
        }
        public async Task<AccountInformation> CheckBalance(string AccountNumber)
        {
            AccountInformation accountInformation = await _context.accountInformation.Where(x => x.AccountNo == AccountNumber).FirstOrDefaultAsync();
            return accountInformation;
        }

        public async Task<AccountInformation> Deposite(string account, decimal amount)
        {

            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:ProductConnection").ToString()))
            {
                //Create the Command Object
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "DepositAmount",
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };

                //Another approach to add Input Parameter
                cmd.Parameters.AddWithValue("@Account", account);
                cmd.Parameters.AddWithValue("@Amount", amount);

                connection.Open();
                cmd.ExecuteNonQuery();
                AccountInformation accountInfo = await _context.accountInformation.Where(x => x.AccountNo == account).FirstOrDefaultAsync();
                return accountInfo;

            }
        }

        public async Task<IEnumerable<AccountInformation>> GetAllAccountInfo()
        {
            var accountInformation = await _context.accountInformation.ToListAsync();
            return accountInformation;
        }

        public async Task<AccountInformation> Withdraw(string account, decimal amount)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:ProductConnection").ToString()))
            {
                //Create the Command Object
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "WithdrawAmount",
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };

                //Another approach to add Input Parameter
                cmd.Parameters.AddWithValue("@Account", account);
                cmd.Parameters.AddWithValue("@Amount", amount);

                connection.Open();
                cmd.ExecuteNonQuery();
                AccountInformation accountInfo = await _context.accountInformation.Where(x => x.AccountNo == account).FirstOrDefaultAsync();
                return accountInfo;

            }
        }

        public async Task<IEnumerable<AccountInformation>> FundTransfer(string SourceAcc, string desAcc, decimal amount)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:ProductConnection").ToString()))
            {
                //Create the Command Object
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "FundTransfer",
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };

                //Another approach to add Input Parameter
                cmd.Parameters.AddWithValue("@SourceAcc", SourceAcc);
                cmd.Parameters.AddWithValue("@DesAcc", desAcc);
                cmd.Parameters.AddWithValue("@Amount", amount);

                connection.Open();
                cmd.ExecuteNonQuery();
                var accountInfo = await _context.accountInformation.ToListAsync();
                return accountInfo;

            }
        }
    }
}
