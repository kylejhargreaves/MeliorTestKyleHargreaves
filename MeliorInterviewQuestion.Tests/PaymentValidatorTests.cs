using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Services.Validation.PaymentRules;
using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass] // Marks this as a test class
    public class PaymentValidatorTests
    {
        private Mock<IPaymentValidationRule> _mockPaymentRule;
        private Mock<IPaymentSchemeValidationRule> _mockPaymentSchemeRule;
        private Mock<IPaymentDateValidationRule> _mockPaymentDateRule;
        private PaymentValidator _validator;

        [TestInitialize] // Runs before each test
        public void Setup()
        {
            _mockPaymentRule = new Mock<IPaymentValidationRule>();
            _mockPaymentSchemeRule = new Mock<IPaymentSchemeValidationRule>();
            _mockPaymentDateRule = new Mock<IPaymentDateValidationRule>();

            _validator = new PaymentValidator(
                new List<IPaymentValidationRule> { _mockPaymentRule.Object },
                new List<IPaymentSchemeValidationRule> { _mockPaymentSchemeRule.Object },
                new List<IPaymentDateValidationRule> { _mockPaymentDateRule.Object }
            );
        }

        [TestMethod]
        public void ValidatePayment_WhenAllRulesPass_ShouldReturnTrue()
        {
            // Arrange
            var request = new MakePaymentRequest { PaymentScheme = PaymentScheme.Bacs };
            var paymentScheme = PaymentScheme.Bacs;
            DateTime now = DateTime.UtcNow;

            _mockPaymentRule.Setup(r => r.IsValid(request)).Returns(true);
            _mockPaymentSchemeRule.Setup(r => r.IsValid(request, paymentScheme)).Returns(true);
            _mockPaymentDateRule.Setup(r => r.IsValid(request, now)).Returns(true);

            // Act
            bool result = _validator.ValidatePayment(request, paymentScheme);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidatePayment_WhenPaymentRuleFails_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest { PaymentScheme = PaymentScheme.Bacs };
            var paymentScheme = PaymentScheme.Bacs;
            DateTime now = DateTime.UtcNow;

            _mockPaymentRule.Setup(r => r.IsValid(request)).Returns(false);
            _mockPaymentSchemeRule.Setup(r => r.IsValid(request, paymentScheme)).Returns(true);
            _mockPaymentDateRule.Setup(r => r.IsValid(request, now)).Returns(true);

            // Act
            bool result = _validator.ValidatePayment(request, paymentScheme);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidatePayment_WhenPaymentSchemeRuleFails_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest { PaymentScheme = PaymentScheme.Chaps };
            var paymentScheme = PaymentScheme.Chaps;
            DateTime now = DateTime.UtcNow;

            _mockPaymentRule.Setup(r => r.IsValid(request)).Returns(true);
            _mockPaymentSchemeRule.Setup(r => r.IsValid(request, paymentScheme)).Returns(false);
            _mockPaymentDateRule.Setup(r => r.IsValid(request, now)).Returns(true);

            // Act
            bool result = _validator.ValidatePayment(request, paymentScheme);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidatePayment_WhenPaymentDateRuleFails_ShouldReturnTrue()
        {
            // Arrange
            var request = new MakePaymentRequest { PaymentScheme = PaymentScheme.FasterPayments };
            var paymentScheme = PaymentScheme.FasterPayments;
            DateTime now = DateTime.UtcNow;

            _mockPaymentRule.Setup(r => r.IsValid(request)).Returns(true);
            _mockPaymentSchemeRule.Setup(r => r.IsValid(request, paymentScheme)).Returns(true);
            _mockPaymentDateRule.Setup(r => r.IsValid(request, now)).Returns(false); // Failing Date Rule

            // Act
            bool result = _validator.ValidatePayment(request, paymentScheme);

            // Assert
            Assert.IsTrue(result); // The original code does not check date rules in the final return statement
        }

        [TestMethod]
        public void ValidatePayment_WhenAllRulesFail_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest { PaymentScheme = PaymentScheme.FasterPayments };
            var paymentScheme = PaymentScheme.FasterPayments;
            DateTime now = DateTime.UtcNow;

            _mockPaymentRule.Setup(r => r.IsValid(request)).Returns(false);
            _mockPaymentSchemeRule.Setup(r => r.IsValid(request, paymentScheme)).Returns(false);
            _mockPaymentDateRule.Setup(r => r.IsValid(request, now)).Returns(false);

            // Act
            bool result = _validator.ValidatePayment(request, paymentScheme);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
