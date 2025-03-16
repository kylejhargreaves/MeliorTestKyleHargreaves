using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.AccountRules
{
    public sealed class AccountPaymentSchemeValidator : IAccountValidationRule
    {
        public bool IsValid(Account account)
        {
            if (account.AllowedPaymentSchemes == 0)
            {
                return false; // No schemes have been allowed
            }
            return true;
        }
    }
}
