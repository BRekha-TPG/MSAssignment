using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionService.Model
{
    [Table("TransactionSummary")]
    public class TransactionSummary
    {
        [Key]
        public int AccountId { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
    }
}
