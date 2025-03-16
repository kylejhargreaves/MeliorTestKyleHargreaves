using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation
{
    public interface IAccountValidator
    {
        public bool ValidateAccount(Account account, AllowedPaymentSchemes allowedPaymentSchemes);
    }
}
