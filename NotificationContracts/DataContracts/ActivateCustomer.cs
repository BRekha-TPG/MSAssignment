namespace NotificationContracts.DataContracts
{
    public class ActivateCustomer : IActivateCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsActive { get; set; }
    }
}
