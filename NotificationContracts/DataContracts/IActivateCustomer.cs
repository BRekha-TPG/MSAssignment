
namespace NotificationContracts.DataContracts
{
    public interface IActivateCustomer
    {
        int CustomerId { get; set; }
        string CustomerName { get; set; }
        bool IsActive { get; set; }
    }
}
