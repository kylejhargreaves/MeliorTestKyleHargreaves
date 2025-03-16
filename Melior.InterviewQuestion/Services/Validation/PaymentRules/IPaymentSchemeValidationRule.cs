using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    public interface IPaymentSchemeValidationRule
    {
        bool IsValid(MakePaymentRequest request, PaymentScheme paymentScheme);
    }
}
