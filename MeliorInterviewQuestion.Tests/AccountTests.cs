using Microsoft.VisualStudio.TestTools.UnitTesting;
using Melior.InterviewQuestion.Types;
using System;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass] // Marks this as a test class
    public class AccountTests
    {
        private Account _account;

        [TestInitialize] // Runs before each test
        public void Setup()
        {
            _account = new Account
            {
                AccountNumber = "123456",
                Balance = 1000m,
                Status = AccountStatus.Live,
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };
        }

        [TestMethod]
        public void CreditAccount_WhenAmountIsPositive_ShouldIncreaseBalance()
        {
            // Arrange
            decimal creditAmount = 500m;

            // Act
            bool result = _account.CreditAccount(creditAmount);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1500m, _account.Balance);
        }

        [TestMethod]
        public void CreditAccount_WhenAmountIsZero_ShouldThrowException()
        {
            // Arrange
            decimal creditAmount = 0m;

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => _account.CreditAccount(creditAmount));
            StringAssert.Contains(ex.Message, "Credit amount must be greater than zero");
        }

        [TestMethod]
        public void CreditAccount_WhenAmountIsNegative_ShouldThrowException()
        {
            // Arrange
            decimal creditAmount = -100m;

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => _account.CreditAccount(creditAmount));
            StringAssert.Contains(ex.Message, "Credit amount must be greater than zero");
        }

        [TestMethod]
        public void DebitAccount_WhenAmountIsPositiveAndSufficientBalance_ShouldDecreaseBalance()
        {
            // Arrange
            decimal debitAmount = 400m;

            // Act
            bool result = _account.DebitAccount(debitAmount);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(600m, _account.Balance);
        }

        [TestMethod]
        public void DebitAccount_WhenAmountIsMoreThanBalance_ShouldReturnFalse()
        {
            // Arrange
            decimal debitAmount = 1500m; // More than balance

            // Act
            bool result = _account.DebitAccount(debitAmount);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1000m, _account.Balance); // Balance should remain unchanged
        }

        [TestMethod]
        public void DebitAccount_WhenAmountIsZero_ShouldThrowException()
        {
            // Arrange
            decimal debitAmount = 0m;

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => _account.DebitAccount(debitAmount));
            StringAssert.Contains(ex.Message, "Debit amount must be greater than zero");
        }

        [TestMethod]
        public void DebitAccount_WhenAmountIsNegative_ShouldThrowException()
        {
            // Arrange
            decimal debitAmount = -100m;

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => _account.DebitAccount(debitAmount));
            StringAssert.Contains(ex.Message, "Debit amount must be greater than zero");
        }
    }
}
