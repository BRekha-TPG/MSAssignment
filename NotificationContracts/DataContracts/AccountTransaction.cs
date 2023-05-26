namespace NotificationContracts.DataContracts
{
    public class AccountTransaction : IAccountTransaction
    {
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string TransactionType { get; set; }
        public string Status { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
