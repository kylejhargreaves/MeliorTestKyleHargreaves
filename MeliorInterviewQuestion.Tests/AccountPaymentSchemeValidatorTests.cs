using Microsoft.VisualStudio.TestTools.UnitTesting;
using Melior.InterviewQuestion.Services.Validation.AccountRules;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass] 
    public class AccountPaymentSchemeValidatorTests
    {
        private AccountPaymentSchemeValidator _validator;

        [TestInitialize] // Runs before each test
        public void Setup()
        {
            _validator = new AccountPaymentSchemeValidator();
        }

        [TestMethod]
        public void IsValid_WhenAccountHasNoAllowedPaymentSchemes_ShouldReturnFalse()
        {
            // Arrange
            var account = new Account { AllowedPaymentSchemes = 0 }; // No payment schemes

            // Act
            bool result = _validator.IsValid(account);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenAccountHasAllowedPaymentSchemes_ShouldReturnTrue()
        {
            // Arrange
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs };

            // Act
            bool result = _validator.IsValid(account);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
