using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    public interface IPaymentValidationRule
    {
        bool IsValid(MakePaymentRequest request);
    }
}
