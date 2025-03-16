using Melior.InterviewQuestion.Types;
using System;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    internal class PaymentWindowValidator : IPaymentValidationRule
    {
        private double PaymentWindowDays { get; }
        public bool IsValid(MakePaymentRequest request)
        {
            if (request.PaymentDate < DateTime.UtcNow.AddDays(-PaymentWindowDays)
               || request.PaymentDate > DateTime.UtcNow.AddDays(PaymentWindowDays))
            {
                return true;
            }
            return false;
        }
    }
}
