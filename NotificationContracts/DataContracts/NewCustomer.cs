namespace NotificationContracts.DataContracts
{
    public class NewCustomer : INewCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
