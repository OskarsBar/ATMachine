using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    public class IncorectMoneyWithdrawalAmountException:Exception
    {
        public IncorectMoneyWithdrawalAmountException() : base("Incorect money Withdrawal amount. Awailable notes 5 10 20 50.")
        {
        }
    }
}
