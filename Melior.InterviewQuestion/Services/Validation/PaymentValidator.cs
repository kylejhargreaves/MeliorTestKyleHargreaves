using Melior.InterviewQuestion.Services.Validation.PaymentRules;
using Melior.InterviewQuestion.Types;
using System.Collections.Generic;
using System.Linq;

namespace Melior.InterviewQuestion.Services.Validation
{
    internal class PaymentValidator : IPaymentValidator
    {
        private readonly List<IPaymentValidationRule> _paymentRules;
        private readonly List<IPaymentSchemeValidationRule> _paymentSchemeValidationRules;

        public PaymentValidator(List<IPaymentValidationRule> paymentRules, List<IPaymentSchemeValidationRule> paymentSchemeValidationRules)
        {
            _paymentRules = paymentRules;
            _paymentSchemeValidationRules = paymentSchemeValidationRules;
        }

        public bool ValidatePayment(MakePaymentRequest request, AllowedPaymentSchemes paymentScheme)
        {
            var paymentRulesPassed = _paymentRules.All(rule => rule.IsValid(request));
            var paymentSchemeRulesPassed = _paymentSchemeValidationRules.All(rule => rule.IsValid(request, paymentScheme));

            return paymentRulesPassed && paymentSchemeRulesPassed;

        }
    }
}
