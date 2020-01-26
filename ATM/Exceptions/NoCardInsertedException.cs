using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    public class NoCardInsertedException:Exception
    {
        public NoCardInsertedException() : base("There is no card in ATM.")
        {
        }
    }
}
