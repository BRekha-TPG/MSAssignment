using Microsoft.EntityFrameworkCore;

namespace Product.API.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {

        }
        public DbSet<TransactionService.Model.AccountInformation> accountInformation { get; set; }
    }
}
