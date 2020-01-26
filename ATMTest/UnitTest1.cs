using System;
using ATM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ATMTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_ATMConstructor()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");

            Assert.AreEqual(atm.Manufacturer, "AtmCo");
            Assert.AreEqual(atm.SerialNumber, "123");

        }
        [TestMethod]
        public void Test_WithdrawWithoutCard()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");
            Assert.ThrowsException<CardNotInsertedException>(() => atm.WithdrawMoney(120));

        }
        [TestMethod]
        public void Test_ATMIsEmtyAtStart()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");

            Assert.AreEqual(atm.ATMMoney.Notes[PaperNote.FiftyEuro], 0);
            Assert.AreEqual(atm.ATMMoney.Notes[PaperNote.TwentyEuro], 0);
            Assert.AreEqual(atm.ATMMoney.Notes[PaperNote.TenEuro], 0);
            Assert.AreEqual(atm.ATMMoney.Notes[PaperNote.FiveEuro], 0);

        }
        [TestMethod]
        public void Test_WithdrawWithCardInserted()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");
            atm.InsertCard("user");
            Assert.AreEqual(atm.CardInserted, true);
            Assert.AreEqual(atm.CardNumber, "user");

        }
        [TestMethod]
        public void Test_ATMInsertMoney()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");

            var test = new Money();
            test.Amount = 285;
            test.Notes = new Dictionary<PaperNote, int> {
                { PaperNote.FiveEuro,1},
                { PaperNote.TenEuro,2},
                { PaperNote.TwentyEuro,3 },
                { PaperNote.FiftyEuro,4}

            };
            atm.LoadMoney(test);
            Assert.AreEqual(atm.ATMMoney.Notes[PaperNote.FiveEuro], 1);
            Assert.AreEqual(atm.ATMMoney.Notes[PaperNote.TenEuro], 2);
            Assert.AreEqual(atm.ATMMoney.Notes[PaperNote.TwentyEuro], 3);
            Assert.AreEqual(atm.ATMMoney.Notes[PaperNote.FiftyEuro], 4);
            Assert.AreEqual(atm.ATMMoney.Amount, 285);
        }
        [TestMethod]
        public void Test_ATMInsertMoneyWrong()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");

            var test = new Money();
            test.Amount = 500;
            test.Notes = new Dictionary<PaperNote, int> {
                { PaperNote.FiveEuro,1},
                { PaperNote.TenEuro,1},
                { PaperNote.TwentyEuro,1 },
                { PaperNote.FiftyEuro,1}

            };
            Assert.ThrowsException<WrongMoneyAmountException>(() => atm.LoadMoney(test));
        }
        [TestMethod]
        public void Test_GetAcountBalanceWithoutCard()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");

            Assert.ThrowsException<CardNotInsertedException>(() => atm.GetCardBalance());

        }
        [TestMethod]
        public void Test_GetAcountBalance()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");
            atm.InsertCard("user");
            Assert.AreEqual(atm.Users["user"], 1000);

        }
        [TestMethod]
        public void Test_WithdrawCardFromEmtyATM()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");


            Assert.ThrowsException<NoCardInsertedException>(() => atm.ReturnCard());
        }
        [TestMethod]
        public void Test_WithdrawCardFromATM()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");

            atm.InsertCard("user");
            Assert.AreEqual(atm.CardInserted, true);
            atm.ReturnCard();
            Assert.AreEqual(atm.CardInserted, false);
        }
        [TestMethod]
        public void Test_WithdrawIncorectAmount()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");

            atm.InsertCard("user");
            Assert.ThrowsException<IncorectMoneyWithdrawalAmountException>(() => atm.WithdrawMoney(23));

        }
        [TestMethod]
        public void Test_WithdrawMoney()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");

            atm.InsertCard("user");
            atm.WithdrawMoney(500);
            var test = atm.RetrievesChargedFees();
            var testItem = test.First();
            Assert.AreEqual(testItem.CardNumber,"user");
            Assert.AreEqual(testItem.WithdrawalFeeAmount, 5);
            
        }
        [TestMethod]
        public void TestEnumTest()
        {
            ATMachine atm = new ATMachine("AtmCo", "123");

            
            Assert.AreEqual(Convert.ToInt32(PaperNote.FiveEuro),5);
            Assert.AreEqual(Convert.ToInt32(PaperNote.TenEuro), 10);
            Assert.AreEqual(Convert.ToInt32(PaperNote.TwentyEuro), 20);
            Assert.AreEqual(Convert.ToInt32(PaperNote.FiftyEuro) ,50);

        }
    }
}
