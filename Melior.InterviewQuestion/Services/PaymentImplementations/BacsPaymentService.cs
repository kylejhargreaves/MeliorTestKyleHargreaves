using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.PaymentImplementations
{
    public sealed class BacsPaymentService : PaymentService
    {
        public override AllowedPaymentSchemes AllowedPaymentSchemes => AllowedPaymentSchemes.Bacs;
        public override PaymentScheme PaymentScheme => PaymentScheme.Bacs;
        public BacsPaymentService(IAccountStoreFactory accountStoreFactory, IPaymentValidator paymentValidator, IAccountValidator accountValidator)
        : base(accountStoreFactory, paymentValidator, accountValidator)
        {
        }
    }
}
