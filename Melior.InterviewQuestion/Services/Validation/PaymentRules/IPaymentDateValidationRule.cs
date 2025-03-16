using Melior.InterviewQuestion.Types;
using System;

namespace Melior.InterviewQuestion.Services.Validation.PaymentRules
{
    public interface IPaymentDateValidationRule
    {
        bool IsValid(MakePaymentRequest request, DateTime paymentValidationRule); 
    }
}
