using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Services.Validation.AccountRules;
using Melior.InterviewQuestion.Types;
using System.Collections.Generic;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass] // Marks this as a test class
    public class AccountValidatorTests
    {
        private Mock<IAccountValidationRule> _mockAccountRule;
        private Mock<IAccountSchemeValidationRule> _mockAccountSchemeRule;
        private AccountValidator _validator;

        [TestInitialize] // Runs before each test
        public void Setup()
        {
            _mockAccountRule = new Mock<IAccountValidationRule>();
            _mockAccountSchemeRule = new Mock<IAccountSchemeValidationRule>();

            _validator = new AccountValidator(
                new List<IAccountValidationRule> { _mockAccountRule.Object },
                new List<IAccountSchemeValidationRule> { _mockAccountSchemeRule.Object }
            );
        }

        [TestMethod]
        public void ValidateAccount_WhenAllRulesPass_ShouldReturnTrue()
        {
            // Arrange
            var account = new Account { Status = AccountStatus.Live };
            var allowedSchemes = AllowedPaymentSchemes.Bacs;

            _mockAccountRule.Setup(r => r.IsValid(account)).Returns(true);
            _mockAccountSchemeRule.Setup(r => r.IsValid(account, allowedSchemes)).Returns(true);

            // Act
            bool result = _validator.ValidateAccount(account, allowedSchemes);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateAccount_WhenAccountRuleFails_ShouldReturnFalse()
        {
            // Arrange
            var account = new Account { Status = AccountStatus.Disabled };
            var allowedSchemes = AllowedPaymentSchemes.Bacs;

            _mockAccountRule.Setup(r => r.IsValid(account)).Returns(false);
            _mockAccountSchemeRule.Setup(r => r.IsValid(account, allowedSchemes)).Returns(true);

            // Act
            bool result = _validator.ValidateAccount(account, allowedSchemes);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateAccount_WhenAccountSchemeRuleFails_ShouldReturnFalse()
        {
            // Arrange
            var account = new Account { Status = AccountStatus.Live };
            var allowedSchemes = AllowedPaymentSchemes.Chaps;

            _mockAccountRule.Setup(r => r.IsValid(account)).Returns(true);
            _mockAccountSchemeRule.Setup(r => r.IsValid(account, allowedSchemes)).Returns(false);

            // Act
            bool result = _validator.ValidateAccount(account, allowedSchemes);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateAccount_WhenBothRulesFail_ShouldReturnFalse()
        {
            // Arrange
            var account = new Account { Status = AccountStatus.Disabled };
            var allowedSchemes = AllowedPaymentSchemes.FasterPayments;

            _mockAccountRule.Setup(r => r.IsValid(account)).Returns(false);
            _mockAccountSchemeRule.Setup(r => r.IsValid(account, allowedSchemes)).Returns(false);

            // Act
            bool result = _validator.ValidateAccount(account, allowedSchemes);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
