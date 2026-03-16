using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Balance after debit is incorrect");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act and assert
            var ex = Assert.ThrowsException<System.ArgumentOutOfRangeException>(
                () => account.Debit(debitAmount));

            // Assert
            StringAssert.Contains(ex.Message, "Сумма снятия не может быть отрицательной");
        }
    }
}