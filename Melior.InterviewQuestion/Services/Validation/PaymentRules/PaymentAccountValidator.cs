using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    public sealed class PaymentAccountValidator : IPaymentValidationRule
    {
        public bool IsValid(MakePaymentRequest request)
        {
            return !string.IsNullOrWhiteSpace(request.DebtorAccountNumber) && !string.IsNullOrWhiteSpace(request.CreditorAccountNumber);
            ;
        }
    }
}
