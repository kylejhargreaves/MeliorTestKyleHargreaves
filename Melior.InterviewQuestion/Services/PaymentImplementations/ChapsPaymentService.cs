using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.PaymentImplementations
{
    public sealed class ChapsPaymentService : PaymentService
    {
        public override AllowedPaymentSchemes AllowedPaymentSchemes => AllowedPaymentSchemes.Chaps;
        public override PaymentScheme PaymentScheme => PaymentScheme.Chaps;
        public ChapsPaymentService(IAccountStoreFactory accountStoreFactory, IPaymentValidator paymentValidator, IAccountValidator accountValidator)
        : base(accountStoreFactory, paymentValidator, accountValidator)
        {
        }
    }
}
