using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Types;
using System.Configuration;
using System.Security.Principal;
using static System.Formats.Asn1.AsnWriter;

namespace Melior.InterviewQuestion.Services
{
    /// <summary>
    /// The abstract payment class that provides most of the functionality, derived classes need to have the Payment scheme defined i.e. a concrete implementation
    /// </summary>
    public abstract class PaymentService : IPaymentService
    {
        protected IAccountDataStore Store { get; }
        private IPaymentValidator PaymentValidator { get; }
        public abstract AllowedPaymentSchemes PaymentScheme { get; } // the abstract property, define for each payment class

        public PaymentService(IAccountStoreFactory accountStoreFactory, IPaymentValidator paymentValidator)
        {
            Store = accountStoreFactory.GetAccountStore();
            PaymentValidator = paymentValidator;
        }
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var debitAccount = Store.GetAccount(request.DebtorAccountNumber);
            var creditAccount = Store.GetAccount(request.DebtorAccountNumber);

            // return early if payment is invalid
            if (!PaymentValidator.ValidatePayment(request, PaymentScheme, debitAccount, creditAccount)) return new MakePaymentResult(false);

            // move this out to the derived classes later
            debitAccount.DebitAccount(request.Amount);
            creditAccount.CreditAccount(request.Amount);
            

            Store.UpdateAccount(debitAccount);
            Store.UpdateAccount(creditAccount);

            return new MakePaymentResult(true);
        }
    }
}
