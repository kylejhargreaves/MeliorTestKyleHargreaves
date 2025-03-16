using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    internal class PaymentAmountValidator : IPaymentValidationRule
    {
        public bool IsValid(MakePaymentRequest request)
        {
            if (request.Amount > 0) return true;
            return false;
        }
    }
}
