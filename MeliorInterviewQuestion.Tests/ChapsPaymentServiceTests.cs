using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.PaymentImplementations;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Types;
using System;

namespace Melior.InterviewQuestion.Tests
{
    [TestClass]
    public class ChapsPaymentServiceTests
    {
        private Mock<IAccountStoreFactory> _mockAccountStoreFactory;
        private Mock<IAccountDataStore> _mockAccountDataStore;
        private Mock<IAccountValidator> _mockAccountValidator;
        private Mock<IPaymentValidator> _mockPaymentValidator;
        private ChapsPaymentService _chapsPaymentService;

        [TestInitialize]
        public void Setup()
        {
            _mockAccountStoreFactory = new Mock<IAccountStoreFactory>();
            _mockAccountDataStore = new Mock<IAccountDataStore>();
            _mockAccountValidator = new Mock<IAccountValidator>();
            _mockPaymentValidator = new Mock<IPaymentValidator>();

            // Mock store behavior
            _mockAccountStoreFactory.Setup(f => f.GetAccountStore()).Returns(_mockAccountDataStore.Object);

            // Instantiate ChapsPaymentService
            _chapsPaymentService = new ChapsPaymentService(
                _mockAccountStoreFactory.Object,
                _mockPaymentValidator.Object,
                _mockAccountValidator.Object
            );
        }

        [TestMethod]
        public void MakePayment_WhenAllValidationsPass_ShouldReturnSuccess()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "123456",
                CreditorAccountNumber = "654321",
                Amount = 100m,
                PaymentScheme = PaymentScheme.Chaps
            };

            var debitAccount = new Account { AccountNumber = "123456", Balance = 500m, Status = AccountStatus.Live };
            var creditAccount = new Account { AccountNumber = "654321", Balance = 200m, Status = AccountStatus.Live };

            _mockAccountDataStore.Setup(s => s.GetAccount("123456")).Returns(debitAccount);
            _mockAccountDataStore.Setup(s => s.GetAccount("654321")).Returns(creditAccount);
            _mockAccountValidator.Setup(v => v.ValidateAccount(debitAccount, AllowedPaymentSchemes.Chaps)).Returns(true);
            _mockAccountValidator.Setup(v => v.ValidateAccount(creditAccount, AllowedPaymentSchemes.Chaps)).Returns(true);
            _mockPaymentValidator.Setup(v => v.ValidatePayment(request, PaymentScheme.Chaps)).Returns(true);

            // Act
            var result = _chapsPaymentService.MakePayment(request);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(400m, debitAccount.Balance); // 500 - 100
            Assert.AreEqual(300m, creditAccount.Balance); // 200 + 100

            _mockAccountDataStore.Verify(s => s.UpdateAccount(debitAccount), Times.Once);
            _mockAccountDataStore.Verify(s => s.UpdateAccount(creditAccount), Times.Once);
        }

        [TestMethod]
        public void MakePayment_WhenDebtorAccountFailsValidation_ShouldReturnFailure()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "123456",
                CreditorAccountNumber = "654321",
                Amount = 100m,
                PaymentScheme = PaymentScheme.Chaps
            };

            var debitAccount = new Account { AccountNumber = "123456", Balance = 500m, Status = AccountStatus.Disabled };

            _mockAccountDataStore.Setup(s => s.GetAccount("123456")).Returns(debitAccount);
            _mockAccountValidator.Setup(v => v.ValidateAccount(debitAccount, AllowedPaymentSchemes.Chaps)).Returns(false);

            // Act
            var result = _chapsPaymentService.MakePayment(request);

            // Assert
            Assert.IsFalse(result.Success);
            _mockAccountDataStore.Verify(s => s.UpdateAccount(It.IsAny<Account>()), Times.Never);
        }

        [TestMethod]
        public void MakePayment_WhenCreditorAccountFailsValidation_ShouldReturnFailure()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "123456",
                CreditorAccountNumber = "654321",
                Amount = 100m,
                PaymentScheme = PaymentScheme.Chaps
            };

            var creditAccount = new Account { AccountNumber = "654321", Balance = 200m, Status = AccountStatus.Disabled };

            _mockAccountDataStore.Setup(s => s.GetAccount("654321")).Returns(creditAccount);
            _mockAccountValidator.Setup(v => v.ValidateAccount(creditAccount, AllowedPaymentSchemes.Chaps)).Returns(false);

            // Act
            var result = _chapsPaymentService.MakePayment(request);

            // Assert
            Assert.IsFalse(result.Success);
            _mockAccountDataStore.Verify(s => s.UpdateAccount(It.IsAny<Account>()), Times.Never);
        }

        [TestMethod]
        public void MakePayment_WhenPaymentValidationFails_ShouldReturnFailure()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "123456",
                CreditorAccountNumber = "654321",
                Amount = 100m,
                PaymentScheme = PaymentScheme.Chaps
            };

            var debitAccount = new Account { AccountNumber = "123456", Balance = 500m, Status = AccountStatus.Live };
            var creditAccount = new Account { AccountNumber = "654321", Balance = 200m, Status = AccountStatus.Live };

            _mockAccountDataStore.Setup(s => s.GetAccount("123456")).Returns(debitAccount);
            _mockAccountDataStore.Setup(s => s.GetAccount("654321")).Returns(creditAccount);
            _mockAccountValidator.Setup(v => v.ValidateAccount(debitAccount, AllowedPaymentSchemes.Chaps)).Returns(true);
            _mockAccountValidator.Setup(v => v.ValidateAccount(creditAccount, AllowedPaymentSchemes.Chaps)).Returns(true);
            _mockPaymentValidator.Setup(v => v.ValidatePayment(request, PaymentScheme.Chaps)).Returns(false);

            // Act
            var result = _chapsPaymentService.MakePayment(request);

            // Assert
            Assert.IsFalse(result.Success);
            _mockAccountDataStore.Verify(s => s.UpdateAccount(It.IsAny<Account>()), Times.Never);
        }
    }
}
