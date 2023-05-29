
namespace NotificationContracts.DataContracts
{
    public interface IActivateCustomer
    {
        int CustomerId { get; set; }
        bool IsActive { get; set; }
    }
}
