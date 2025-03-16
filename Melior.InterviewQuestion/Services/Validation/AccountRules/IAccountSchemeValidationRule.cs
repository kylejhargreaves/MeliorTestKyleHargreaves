using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Validation.AccountRules
{
    internal interface IAccountSchemeValidationRule
    {
        public bool IsValid(Account account, AllowedPaymentSchemes paymentScheme);
    }
}
