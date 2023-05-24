using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionService.Model
{
    [Table("AccountInformation")]
    public class AccountInformation
    {
        public AccountInformation() { }

        [Key]
        public Guid Id { get; set; }

        public string AccountNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal CurrentBalance { get; set; }

    }
}
