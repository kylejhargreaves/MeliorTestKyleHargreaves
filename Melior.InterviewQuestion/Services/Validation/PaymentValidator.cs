using Melior.InterviewQuestion.Services.Validation.PaymentRules;
using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Melior.InterviewQuestion.Services.Validation
{
    public class PaymentValidator : IPaymentValidator
    {
        private readonly List<IPaymentValidationRule> _paymentRules;
        private readonly List<IPaymentSchemeValidationRule> _paymentSchemeValidationRules;
        private readonly List<IPaymentDateValidationRule> _paymentDateRules;

        public PaymentValidator(List<IPaymentValidationRule> paymentRules, List<IPaymentSchemeValidationRule> paymentSchemeValidationRules, List<IPaymentDateValidationRule> paymentDateRules)
        {
            _paymentRules = paymentRules;
            _paymentSchemeValidationRules = paymentSchemeValidationRules;
            _paymentDateRules = paymentDateRules;
        }

        public bool ValidatePayment(MakePaymentRequest request, PaymentScheme paymentScheme)
        {
            var paymentRulesPassed = _paymentRules.All(rule => rule.IsValid(request));
            var paymentSchemeRulesPassed = _paymentSchemeValidationRules.All(rule => rule.IsValid(request, paymentScheme));
            var paymentDateRulesPassed = _paymentDateRules.All(rule=> rule.IsValid(request, DateTime.UtcNow));
            return paymentRulesPassed && paymentSchemeRulesPassed;

        }
    }
}
