using Microsoft.VisualStudio.TestTools.UnitTesting;
using Melior.InterviewQuestion.Services.Validation.AccountRules;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass] // Marks this as a test class
    public class AccountSchemesAllowedValidatorTests
    {
        private AccountSchemesAllowedValidator _validator;

        [TestInitialize] // Runs before each test
        public void Setup()
        {
            _validator = new AccountSchemesAllowedValidator();
        }

        [TestMethod]
        public void IsValid_WhenAccountHasRequestedPaymentScheme_ShouldReturnTrue()
        {
            // Arrange
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs };

            // Act
            bool result = _validator.IsValid(account, AllowedPaymentSchemes.Bacs);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenAccountDoesNotHaveRequestedPaymentScheme_ShouldReturnFalse()
        {
            // Arrange
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps };

            // Act
            bool result = _validator.IsValid(account, AllowedPaymentSchemes.Bacs);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenAccountHasMultipleSchemesAndRequestedOneIsIncluded_ShouldReturnTrue()
        {
            // Arrange
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs | AllowedPaymentSchemes.Chaps };

            // Act
            bool result = _validator.IsValid(account, AllowedPaymentSchemes.Bacs);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenAccountHasNoAllowedSchemes_ShouldReturnFalse()
        {
            // Arrange
            var account = new Account { AllowedPaymentSchemes = 0 }; // No schemes allowed

            // Act
            bool result = _validator.IsValid(account, AllowedPaymentSchemes.Bacs);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
