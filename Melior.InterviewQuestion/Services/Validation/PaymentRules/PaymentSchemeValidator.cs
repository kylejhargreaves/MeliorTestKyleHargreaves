using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    public class PaymentSchemeValidator : IPaymentSchemeValidationRule
    {
        public bool IsValid(MakePaymentRequest request, AllowedPaymentSchemes paymentScheme)
        {
            if (paymentScheme.HasFlag(request.PaymentScheme)) return true;
            return false;
        }
    }
}
