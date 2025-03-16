using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    internal interface IPaymentValidationRule
    {
        bool IsValid(MakePaymentRequest request);
    }
}
