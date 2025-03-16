using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Melior.InterviewQuestion.Services.Validation.PaymentRules;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass]
    public class PaymentWindowValidatorTests
    {
        private PaymentWindowValidator _validator;
        private readonly double _windowDays = 30; // Set default window

        [TestInitialize]
        public void Setup()
        {
            _validator = new PaymentWindowValidator(_windowDays);
        }

        [TestMethod]
        public void IsValid_WhenPaymentDateIsWithinWindow_ShouldReturnTrue()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                PaymentDate = DateTime.UtcNow
            };

            // Act
            bool result = _validator.IsValid(request, DateTime.UtcNow);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenPaymentDateIsExactlyOnLowerBoundary_ShouldReturnTrue()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                PaymentDate = DateTime.UtcNow.AddDays(-_windowDays)
            };

            // Act
            bool result = _validator.IsValid(request, DateTime.UtcNow);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenPaymentDateIsExactlyOnUpperBoundary_ShouldReturnTrue()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                PaymentDate = DateTime.UtcNow.AddDays(_windowDays)
            };

            // Act
            bool result = _validator.IsValid(request, DateTime.UtcNow);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenPaymentDateIsBeforeWindow_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                PaymentDate = DateTime.UtcNow.AddDays(-_windowDays - 1)
            };

            // Act
            bool result = _validator.IsValid(request, DateTime.UtcNow);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenPaymentDateIsAfterWindow_ShouldReturnFalse()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                PaymentDate = DateTime.UtcNow.AddDays(_windowDays + 1)
            };

            // Act
            bool result = _validator.IsValid(request, DateTime.UtcNow);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
