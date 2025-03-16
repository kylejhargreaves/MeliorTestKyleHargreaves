using Microsoft.VisualStudio.TestTools.UnitTesting;
using Melior.InterviewQuestion.Services.Validation.PaymentRules;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass] // Marks this as a test class
    public class PaymentAccountValidatorTests
    {
        private PaymentAccountValidator _validator;

        [TestInitialize] // Runs before each test
        public void Setup()
        {
            _validator = new PaymentAccountValidator();
        }

        [TestMethod]
        public void IsValid_WhenBothDebtorAndCreditorAccountNumbersArePresent_ShouldReturnTrue()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "123456",
                CreditorAccountNumber = "654321"
            };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenDebtorAccountNumberIsEmpty_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "",
                CreditorAccountNumber = "654321"
            };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenCreditorAccountNumberIsEmpty_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "123456",
                CreditorAccountNumber = ""
            };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenBothAccountNumbersAreEmpty_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "",
                CreditorAccountNumber = ""
            };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenDebtorAccountNumberIsNull_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = null,
                CreditorAccountNumber = "654321"
            };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenCreditorAccountNumberIsNull_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "123456",
                CreditorAccountNumber = null
            };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
