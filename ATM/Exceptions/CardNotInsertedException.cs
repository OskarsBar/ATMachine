using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    public class CardNotInsertedException:Exception
    {
        public CardNotInsertedException():base("Card slot is empty.")
        {
        }
    }
}
