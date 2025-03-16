using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.PaymentImplementations
{
    internal class BacsPaymentService : PaymentService
    {
        public override PaymentScheme PaymentScheme => PaymentScheme.Bacs;
    }
}
