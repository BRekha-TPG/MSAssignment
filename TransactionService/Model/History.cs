using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionService.Model
{
    [Table("History")]
    public class History
    {
        public History()
        {

        }

        [Key]
        public Guid Id { get; set; }
        public string AccountNo { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public int TransactionNo { get; set; }
    }
}
