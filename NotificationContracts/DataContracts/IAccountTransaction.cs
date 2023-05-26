
namespace NotificationContracts.DataContracts
{
    public interface IAccountTransaction
    {
        string FromAccount { get; set; }
        string ToAccount { get; set; }
        string TransactionType { get; set; }
        string Status { get; set; }
        decimal CurrentBalance { get; set; }
    }
}
