using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.AccountRules
{
    internal interface IAccountValidationRule
    {
        public bool IsValid(Account account);
    }
}
