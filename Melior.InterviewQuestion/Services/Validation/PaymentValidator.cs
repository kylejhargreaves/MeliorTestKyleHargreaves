using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.Validation
{
    internal class PaymentValidator : IPaymentValidator
    {
        private double PaymentWindowDays { get; }
        public bool ValidatePayment(MakePaymentRequest request, PaymentScheme paymentScheme, IAccount debitAccount, IAccount creditAccount)
        {
            if (request.PaymentScheme != paymentScheme) return false;
            if(request.Amount <= 0) return false;
            if (string.IsNullOrWhiteSpace(request.DebtorAccountNumber)) return false;
            if (string.IsNullOrWhiteSpace(request.CreditorAccountNumber)) return false;
            if (request.CreditorAccountNumber == request.DebtorAccountNumber) return false;
            if (request.PaymentDate < DateTime.UtcNow.AddDays(-PaymentWindowDays)
                || request.PaymentDate > DateTime.UtcNow.AddDays(PaymentWindowDays))
            {
                return false;
            }

            if (!debitAccount.VerifyAccount(request.PaymentScheme))
            {
                return false;
            }
            if (!creditAccount.VerifyAccount(request.PaymentScheme))
            {
                return false;
            }

            return true;
        }
    }
}
