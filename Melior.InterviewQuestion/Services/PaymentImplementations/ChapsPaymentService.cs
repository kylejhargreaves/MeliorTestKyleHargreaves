using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.Validation;
using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.PaymentImplementations
{
    internal class ChapsPaymentService : PaymentService
    {
        public override PaymentScheme PaymentScheme => PaymentScheme.Chaps;
        public ChapsPaymentService(IAccountStoreFactory accountStoreFactory, IPaymentValidator paymentValidator)
        : base(accountStoreFactory, paymentValidator)
        {
        }
    }
}
