using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation
{
    public interface IPaymentValidator
    {
        public bool ValidatePayment(MakePaymentRequest request, PaymentScheme paymentScheme);
    }
}
