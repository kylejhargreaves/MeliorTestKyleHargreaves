using Melior.InterviewQuestion.Types;
using System;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    public sealed class PaymentWindowValidator : IPaymentDateValidationRule
    {
        private double PaymentWindowDays { get; }
        public PaymentWindowValidator(double paymentWindowDays = 30)// just default this to 30 days
        {
            PaymentWindowDays = paymentWindowDays;
        }
        public bool IsValid(MakePaymentRequest request, DateTime currentTime)
        {
            DateTime today = currentTime.Date;
            DateTime lowerBoundary = today.AddDays(-PaymentWindowDays);
            DateTime upperBoundary = today.AddDays(PaymentWindowDays);

            return request.PaymentDate.Date >= lowerBoundary && request.PaymentDate.Date <= upperBoundary;
        }
    }
}
