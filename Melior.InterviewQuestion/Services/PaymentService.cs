using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Types;
using System.Configuration;
using static System.Formats.Asn1.AsnWriter;

namespace Melior.InterviewQuestion.Services
{
    public abstract class PaymentService : IPaymentService
    {
        protected IAccountDataStore Store { get; }
        private IPaymentValidator PaymentValidator { get; }
        public abstract PaymentScheme PaymentScheme { get; } // the abstract property, define for each payment class

        public PaymentService(IAccountStoreFactory accountStoreFactory, IPaymentValidator paymentValidator)
        {
            Store = accountStoreFactory.GetAccountStore();
            PaymentValidator = paymentValidator;
        }
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];

            var debitAccount = Store.GetAccount(request.DebtorAccountNumber);
            var creditAccount = Store.GetAccount(request.DebtorAccountNumber);
            
            // return early if payment is invalid
            if (!PaymentValidator.ValidatePayment(request, PaymentScheme, debitAccount, creditAccount)) return new MakePaymentResult(false);


            // move this out to the derived classes later

            var result = new MakePaymentResult();

            //switch (request.PaymentScheme)
            //{
            //    case PaymentScheme.Bacs:
            //        if (account == null)
            //        {
            //            result.Success = false;
            //        }
            //        else if (!account.AllowedPaymentSchemes.HasFlag(PaymentScheme))
            //        {
            //            result.Success = false;
            //        }
            //        break;

            //    case PaymentScheme.FasterPayments:
            //        if (account == null)
            //        {
            //            result.Success = false;
            //        }
            //        else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
            //        {
            //            result.Success = false;
            //        }
            //        else if (account.Balance < request.Amount)
            //        {
            //            result.Success = false;
            //        }
            //        break;

            //    case PaymentScheme.Chaps:
            //        if (account == null)
            //        {
            //            result.Success = false;
            //        }
            //        else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
            //        {
            //            result.Success = false;
            //        }
            //        else if (account.Status != AccountStatus.Live)
            //        {
            //            result.Success = false;
            //        }
            //        break;
            //}

            if (result.Success)
            {
                debitAccount.DebitAccount(request.Amount);
                creditAccount.CreditAccount(request.Amount);


                Store.UpdateAccount(debitAccount);
                Store.UpdateAccount(creditAccount);
            }

            return result;
        }
    }
}
