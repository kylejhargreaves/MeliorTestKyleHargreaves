using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.AccountRules
{
    public interface IAccountValidationRule
    {
        public bool IsValid(Account account);
    }
}
