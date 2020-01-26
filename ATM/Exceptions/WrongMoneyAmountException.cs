using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    public class WrongMoneyAmountException:Exception
    {
        public WrongMoneyAmountException() : base("Money amount is different then money note count.")
        {

        }
    }
}
