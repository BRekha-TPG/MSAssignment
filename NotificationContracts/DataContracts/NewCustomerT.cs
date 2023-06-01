using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationContracts.DataContracts
{
    public class NewCustomerT : INewCustomerT
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Accountnumber { get; set; }
        public string Balance { get; set; }
        public string Address { get; set; }
    }
}
