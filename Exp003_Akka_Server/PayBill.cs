using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp003_Akka_Server
{
    public class PayBill
    {
        public readonly string Customer;

        public readonly decimal Ammount;

        public readonly string Account;

        public PayBill(string toCustomer, string fromAccount, decimal theAmmount)
        {
            this.Customer = toCustomer;
            this.Account = fromAccount;
            this.Ammount = theAmmount;
        }

    }
}
