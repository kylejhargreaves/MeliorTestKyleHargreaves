using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    public sealed class SenderIsReceiverValidator : IPaymentValidationRule
    {
        public bool IsValid(MakePaymentRequest request)
        {
            if (request.CreditorAccountNumber != request.DebtorAccountNumber) return true;
            return false;
        }
    }
}
