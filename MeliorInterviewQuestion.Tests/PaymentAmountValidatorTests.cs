using Microsoft.VisualStudio.TestTools.UnitTesting;
using Melior.InterviewQuestion.Services.Validation.PaymentRules;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass] // Marks this as a test class
    public class PaymentAmountValidatorTests
    {
        private PaymentAmountValidator _validator;

        [TestInitialize] // Runs before each test
        public void Setup()
        {
            _validator = new PaymentAmountValidator();
        }

        [TestMethod]
        public void IsValid_WhenAmountIsGreaterThanZero_ShouldReturnTrue()
        {
            // Arrange
            var request = new MakePaymentRequest { Amount = 100 };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenAmountIsZero_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest { Amount = 0 };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenAmountIsNegative_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest { Amount = -50 };

            // Act
            bool result = _validator.IsValid(request);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
