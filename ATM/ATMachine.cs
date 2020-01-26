using ATM.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATMachine:IATMachine
    {
        public ATMachine(string manuacturer, string serialNumber)
        {
            Manufacturer = manuacturer;
            SerialNumber = serialNumber;

            //Initialize Papernotes in ATM at start
            ATMMoney = new Money();
            
            ATMMoney.Notes = new Dictionary<PaperNote, int> {
                { PaperNote.FiveEuro,0},
                { PaperNote.TenEuro,0},
                { PaperNote.TwentyEuro,0},
                { PaperNote.FiftyEuro,0}

            };
           
        } 

        public string Manufacturer { get; }
        public string SerialNumber { get; }
        public Money ATMMoney; 
        public bool CardInserted { get; set; }
        public string CardNumber { get; set; }
        /// <summary>
        /// Used for testing, there was no specific rules about how to calculate
        /// balance and where to store it
        /// </summary>
        public Dictionary<string, decimal> Users = new Dictionary<string, decimal>
        {
            {"user",1000 }
        };
        
        public decimal GetCardBalance()
        {
            if (!CardInserted)
            {
                throw new CardNotInsertedException();
            }
            else
            {
                return Users[CardNumber];

            }
        }

        public void InsertCard(string cardNumber)
        {
            if (CardInserted)
            {
                throw new CarkAldredyInsertedException();
            }
            else
            {
                CardNumber = cardNumber;
                CardInserted = true;

            }
        }

        public void LoadMoney(Money money)
        {
            if (!Validation.EqualMoneyNotesAndAmout(money))
            {
                throw new WrongMoneyAmountException();
                
            }
            else
            {
                ATMMoney.Amount = +money.Amount;
                ATMMoney.Notes[PaperNote.FiveEuro] = +money.Notes[PaperNote.FiveEuro];
                ATMMoney.Notes[PaperNote.TenEuro] = +money.Notes[PaperNote.TenEuro];
                ATMMoney.Notes[PaperNote.TwentyEuro] = +money.Notes[PaperNote.TwentyEuro];
                ATMMoney.Notes[PaperNote.FiftyEuro] = +money.Notes[PaperNote.FiftyEuro];
            }
        }

        public IEnumerable<Fee> RetrievesChargedFees()
        {
            throw new NotImplementedException();
        }

        public void ReturnCard()
        {
            if (!CardInserted)
                throw new NoCardInsertedException();

            else
                CardInserted = false;
        }

        public Money WithdrawMoney(int amount)
        {
            if (!CardInserted)
                throw new CardNotInsertedException();
            else if (amount % 5 != 0)
                throw new IncorectMoneyWithdrawalAmountException();
            else
            {
                throw new NotImplementedException();
            }
        }
    }
    public struct Money
    {
        public int Amount { get; set; }
        public Dictionary<PaperNote, int> Notes { get; set; }
    }
    public struct Fee
    {
        public string cardNumber { get;set;}
        public decimal WithdrawalFeeAmount { get; set; }
        public DateTime WithdrawalDate { get; set; }
    }

    public enum PaperNote
    {
        FiveEuro=5,
        TenEuro=10,
        TwentyEuro=20,
        FiftyEuro=50

    }
}
