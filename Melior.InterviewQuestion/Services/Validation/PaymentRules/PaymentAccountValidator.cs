using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    internal class PaymentAccountValidator : IPaymentValidationRule
    {
        public bool IsValid(MakePaymentRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.DebtorAccountNumber) && !string.IsNullOrWhiteSpace(request.CreditorAccountNumber)) return false;
            return false;
        }
    }
}
