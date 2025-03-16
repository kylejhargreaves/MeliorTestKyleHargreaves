using Microsoft.VisualStudio.TestTools.UnitTesting;
using Melior.InterviewQuestion.Services.Validation.PaymentRules;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass]
    public class SenderIsReceiverValidatorTests
    {
        private SenderIsReceiverValidator _validator;

        [TestInitialize] 
        public void Setup()
        {
            _validator = new SenderIsReceiverValidator();
        }

        [TestMethod]
        public void IsValid_WhenSenderAndReceiverAreDifferent_ShouldReturnTrue()
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
        public void IsValid_WhenSenderAndReceiverAreTheSame_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "123456",
                CreditorAccountNumber = "123456" // Same as DebtorAccountNumber
            };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenDebtorAccountNumberIsEmptyAndDifferent_ShouldReturnTrue()
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
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenCreditorAccountNumberIsEmptyAndDifferent_ShouldReturnTrue()
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
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenBothDebtorAndCreditorAccountNumbersAreEmpty_ShouldReturnFalse()
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
        public void IsValid_WhenDebtorAccountNumberIsNullAndDifferent_ShouldReturnTrue()
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
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenCreditorAccountNumberIsNullAndDifferent_ShouldReturnTrue()
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
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenBothDebtorAndCreditorAccountNumbersAreNull_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = null,
                CreditorAccountNumber = null
            };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
