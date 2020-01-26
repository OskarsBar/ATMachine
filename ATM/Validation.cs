using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Validation
    {
        public static bool EqualMoneyNotesAndAmout(Money money)
        {
            if (money.Amount == money.Notes[PaperNote.FiveEuro] * 5 +
                             money.Notes[PaperNote.TenEuro] * 10 +
                             money.Notes[PaperNote.TwentyEuro] * 20 +
                             money.Notes[PaperNote.FiftyEuro] * 50 )
            {
                return true;
            }
            else
                return false;
        }
    }
}
