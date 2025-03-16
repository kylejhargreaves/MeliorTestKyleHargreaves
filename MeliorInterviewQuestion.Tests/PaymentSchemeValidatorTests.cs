using Microsoft.VisualStudio.TestTools.UnitTesting;
using Melior.InterviewQuestion.Services.Validation.PaymentRules;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass]
    public class PaymentSchemeValidatorTests
    {
        private PaymentSchemeValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new PaymentSchemeValidator();
        }

        [TestMethod]
        public void IsValid_WhenPaymentSchemeIsAllowed_ShouldReturnTrue()
        {
            // Arrange
            var request = new MakePaymentRequest { PaymentScheme = PaymentScheme.Bacs };
            var allowedSchemes = PaymentScheme.Bacs;

            // Act
            bool result = _validator.IsValid(request, allowedSchemes);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenPaymentSchemeIsNotAllowed_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest { PaymentScheme = PaymentScheme.FasterPayments };
            var allowedSchemes = PaymentScheme.Bacs;

            // Act
            bool result = _validator.IsValid(request, allowedSchemes);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenNoPaymentSchemesAreAllowed_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest { PaymentScheme = PaymentScheme.Bacs };
            var allowedSchemes = (PaymentScheme)0; // No schemes allowed
            
            // Act
            bool result = _validator.IsValid(request, allowedSchemes);

            // Assert
            Assert.IsFalse(result);
        }

    }
}