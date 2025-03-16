using Melior.InterviewQuestion.Services.Validation.AccountRules;
using Melior.InterviewQuestion.Types;
using System.Collections.Generic;
using System.Linq;

namespace Melior.InterviewQuestion.Services.Validation
{
    public sealed class AccountValidator : IAccountValidator
    {
        private readonly List<IAccountValidationRule> _accountRules;
        private readonly List<IAccountSchemeValidationRule> _accountSchemeValidationRules;

        public AccountValidator(List<IAccountValidationRule> paymentRules, List<IAccountSchemeValidationRule> paymentSchemeValidationRules)
        {
            _accountRules = paymentRules;
            _accountSchemeValidationRules = paymentSchemeValidationRules;
        }

        public bool ValidateAccount(Account account, AllowedPaymentSchemes paymentSchemes)
        {
            var accountRulesPassed = _accountRules.All(rule => rule.IsValid(account));
            var accountSchemeRulesPassed = _accountSchemeValidationRules.All(rule => rule.IsValid(account, paymentSchemes));

            return accountRulesPassed && accountSchemeRulesPassed;
        }
    }
}
