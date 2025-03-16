using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.Validation
{
    public interface IPaymentValidator
    {
        public bool ValidatePayment(MakePaymentRequest request, PaymentScheme paymentScheme, IAccount debitAccount, IAccount creditAccount);
    }
}
