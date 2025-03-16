using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    public sealed class PaymentSchemeValidator : IPaymentSchemeValidationRule
    {
        public bool IsValid(MakePaymentRequest request, PaymentScheme paymentScheme)
        {
            if (paymentScheme == request.PaymentScheme) return true;
            return false;
        }
    }
}
