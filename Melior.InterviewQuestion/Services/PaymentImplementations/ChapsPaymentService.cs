using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.PaymentImplementations
{
    internal class ChapsPaymentService : PaymentService
    {
        public override AllowedPaymentSchemes PaymentScheme => AllowedPaymentSchemes.Chaps;
        public ChapsPaymentService(IAccountStoreFactory accountStoreFactory, IPaymentValidator paymentValidator, IAccountValidator accountValidator)
        : base(accountStoreFactory, paymentValidator, accountValidator)
        {
        }
    }
}
