using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.PaymentImplementations
{
    internal class BacsPaymentService : PaymentService
    {
        public override AllowedPaymentSchemes PaymentScheme => AllowedPaymentSchemes.Bacs;

        public BacsPaymentService(IAccountStoreFactory accountStoreFactory, IPaymentValidator paymentValidator, IAccountValidator accountValidator)
        : base(accountStoreFactory, paymentValidator, accountValidator)
        {
        }
    }
}
