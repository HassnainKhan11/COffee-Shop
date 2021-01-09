using System;

namespace Coffeeshop
{
    public class Coffeshop
    {
        private string p_name;
        private double m_balance;
        private const string priceExceedsTheAmount = "Price exceeds balance";
        private const string debitAmountLessThanZeroMessage = "Price less than zero";
        private bool m_frozen = false;
        private Coffeshop()
        {
        }
        public Coffeshop(string customerName, double balance)
        {
            P_name = customerName;
            Balance1 = balance;
        }

        public string CustomerName
        {
            get { return P_name; }
        }
        public double Balance
        {
            get { return Balance1; }
        }

        public string P_name { get => P_name1; set => P_name1 = value; }
        public double Balance1 { get => Balance2; set => Balance2 = value; }

        public static string PriceExceedsTheAmount => PriceExceedsTheAmount1;

        public static string DebitAmountLessThanZeroMessage => DebitAmountLessThanZeroMessage1;

        public bool Frozen { get => Frozen1; set => Frozen1 = value; }
        public string P_name1 { get => p_name; set => p_name = value; }
        public double Balance2 { get => m_balance; set => m_balance = value; }

        public static string PriceExceedsTheAmount1 => priceExceedsTheAmount;

        public static string DebitAmountLessThanZeroMessage1 => debitAmountLessThanZeroMessage;

        public bool Frozen1 { get => m_frozen; set => m_frozen = value; }

        public void pay(double amount)
        {
            if (Frozen)
            {
                throw new Exception("Account frozen");
            }


            if (amount > Balance1)
            {
                throw new ArgumentOutOfRangeException("amount", amount, PriceExceedsTheAmount);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            Balance1 -= amount;
        }
        public void Amountavailable(double amount)
        {
            if (Frozen)
            {
                throw new Exception("Account frozen");
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            Balance1 -= amount;
        }

        private void FreezeAccount()
        {
            Frozen = true;
        }
        private void UnfreezeAccount()
        {
            Frozen = false;
        }
        public static void Main()
        {
            Coffeshop cShop = new Coffeshop("John", 11.22);
            cShop.Amountavailable(90.12);
            cShop.pay(05.22);
            Console.WriteLine("Current balance is ${0}", cShop.Balance);
        }
    }
}

}

using System;
using CoffeShopNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeShopNS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CoffePrice_CustomerHasNotEnoughMoney_UpdatesBalance()
        {
            double AmountPaid = 11.99;
            double Amountdeducted = 4.55;
            double change = 7.44;
            Coffeshop account = new Coffeshop("Hassnain Khan", AmountPaid);

            account.Debit(Amountdeducted);

            double actual = account.Balance;
            Assert.AreEqual(change, actual, 0.001, "Sorry, Amount not paid succesfully");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CoffePrice_CustomersAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double AmountPaid = 11.99;
            double AccountIsEmpty = -100.00;
            Coffeshop account = new Coffeshop("Hassnain Khan", AmountPaid);

            account.Debit(AccountIsEmpty);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CoffePrice_TransactionNotSuccesfull_ShouldThrowArgumentOutOfRange()
        {
            double AmountPaid = 11.99;
            double AccountIsEmpty = -100.00;
            Coffeshop account = new Coffeshop("Hassnain Khan", AmountPaid);

            account.Debit(AccountIsEmpty);

        }


        [TestMethod]
        public void CoffePrice_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double AmountPaid = 11.99;
            double ActualAmount = 20.0;
            Coffeshop account = new Coffeshop("Hassnain Khan", AmountPaid);

            try
            {
                account.Debit(ActualAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Coffeshop.DebitAmountExceedsBalanceMessage);
            }
        }
    }
}
