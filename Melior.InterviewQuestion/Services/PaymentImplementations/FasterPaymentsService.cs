using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.PaymentImplementations
{
    internal class FasterPaymentsService : PaymentService
    {
        public override AllowedPaymentSchemes PaymentScheme => AllowedPaymentSchemes.FasterPayments;
        public FasterPaymentsService(IAccountStoreFactory accountStoreFactory, IPaymentValidator paymentValidator, IAccountValidator accountValidator)
        : base(accountStoreFactory, paymentValidator, accountValidator)
        {
        }
    }
}
