using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.AccountRules
{
    internal class AccountSchemesAllowedValidator : IAccountSchemeValidationRule
    {
        public bool IsValid(Account account, AllowedPaymentSchemes paymentScheme)
        {
            if (!account.AllowedPaymentSchemes.HasFlag(paymentScheme))
            {
                return false; // The requested payment scheme isn't available
            }
            return true;
        }

    }
}
