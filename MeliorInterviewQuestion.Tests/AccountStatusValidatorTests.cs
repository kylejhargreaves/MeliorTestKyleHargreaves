using Microsoft.VisualStudio.TestTools.UnitTesting;
using Melior.InterviewQuestion.Services.Validation.AccountRules;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass] // Marks this as a test class
    public class AccountStatusValidatorTests
    {
        private AccountStatusValidator _validator;

        [TestInitialize] // Runs before each test
        public void Setup()
        {
            _validator = new AccountStatusValidator();
        }

        [TestMethod]
        public void IsValid_WhenAccountIsLive_ShouldReturnTrue()
        {
            // Arrange
            var account = new Account { Status = AccountStatus.Live };

            // Act
            bool result = _validator.IsValid(account);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenAccountIsDisabled_ShouldReturnFalse()
        {
            // Arrange
            var account = new Account { Status = AccountStatus.Disabled };

            // Act
            bool result = _validator.IsValid(account);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenAccountIsDisabled_ShouldReturnTrue()
        {
            // Arrange
            var account = new Account { Status = AccountStatus.Disabled };

            // Act
            bool result = _validator.IsValid(account);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
