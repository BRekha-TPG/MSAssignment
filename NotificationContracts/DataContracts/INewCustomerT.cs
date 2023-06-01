namespace NotificationContracts.DataContracts
{
    public interface INewCustomerT : INewCustomer
    {
        string Accountnumber { get; set; }

        string Balance { get; set; }
        string Address { get; set; }
    }
}
