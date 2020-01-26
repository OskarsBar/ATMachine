using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    class CarkAldredyInsertedException:Exception
    {
        public CarkAldredyInsertedException() : base("Card already in slot.")
        {
        }
    }
}
