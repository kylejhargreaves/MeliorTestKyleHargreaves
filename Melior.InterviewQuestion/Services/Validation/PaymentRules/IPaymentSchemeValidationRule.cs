using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    internal interface IPaymentSchemeValidationRule
    {
        bool IsValid(MakePaymentRequest request, AllowedPaymentSchemes paymentScheme);
    }
}
