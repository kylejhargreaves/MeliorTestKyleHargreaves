using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.AccountRules
{
    public sealed class AccountStatusValidator : IAccountValidationRule
    {
        public bool IsValid(Account account)
        {
            if (account.Status == AccountStatus.Disabled)
            {
                return false; // The account should not be disabled
            }
            return true;
        }
    }
}
