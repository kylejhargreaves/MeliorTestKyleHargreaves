using Microsoft.VisualStudio.TestTools.UnitTesting;
using Melior.InterviewQuestion.Services.Validation.PaymentRules;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass] // Marks this as a test class
    public class PaymentSchemeValidatorTests
    {
        private PaymentSchemeValidator _validator;

        [TestInitialize] // Runs before each test
        public void Setup()
        {
            _validator = new PaymentSchemeValidator();
        }

        [TestMethod]
        public void IsValid_WhenPaymentSchemeIsAllowed_ShouldReturnTrue()
        {
            // Arrange
            var request = new MakePaymentRequest { PaymentScheme = PaymentScheme.Bacs };
            var allowedSchemes = AllowedPaymentSchemes.Bacs | AllowedPaymentSchemes.Chaps;

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
            var allowedSchemes = AllowedPaymentSchemes.Bacs | AllowedPaymentSchemes.Chaps;

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
            var allowedSchemes = (AllowedPaymentSchemes)0; // No schemes allowed

            // Act
            bool result = _validator.IsValid(request, allowedSchemes);

            // Assert
            Assert.IsFalse(result);
        }

    }
}