﻿using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services
{
    /// <summary>
    /// The abstract payment class that provides most of the functionality, derived classes need to have the Payment scheme defined i.e. a concrete implementation
    /// </summary>
    public abstract class PaymentService : IPaymentService
    {
        private IAccountDataStore Store { get; }
        private IAccountValidator AccountValidator { get; }
        private IPaymentValidator PaymentValidator { get; }

        public abstract AllowedPaymentSchemes AllowedPaymentSchemes { get; } // the abstract property, define for each payment class
        public abstract PaymentScheme PaymentScheme { get; } // the abstract property, define for each payment class

        public PaymentService(IAccountStoreFactory accountStoreFactory, IPaymentValidator paymentValidator, IAccountValidator accountValidator)
        {
            Store = accountStoreFactory.GetAccountStore();
            PaymentValidator = paymentValidator;
            AccountValidator = accountValidator;
        }
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var debitAccount = Store.GetAccount(request.DebtorAccountNumber);
            var creditAccount = Store.GetAccount(request.CreditorAccountNumber);

            if (!AccountValidator.ValidateAccount(debitAccount, AllowedPaymentSchemes)) return new MakePaymentResult(false);
            if (!AccountValidator.ValidateAccount(creditAccount, AllowedPaymentSchemes)) return new MakePaymentResult(false);
            if (!PaymentValidator.ValidatePayment(request, PaymentScheme)) return new MakePaymentResult(false);

            // move this out to the derived classes later
            debitAccount.DebitAccount(request.Amount);
            creditAccount.CreditAccount(request.Amount);
            

            Store.UpdateAccount(debitAccount);
            Store.UpdateAccount(creditAccount);

            return new MakePaymentResult(true);
        }
    }
}
