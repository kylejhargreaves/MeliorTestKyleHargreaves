using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Types
{
    public interface IAccount
    {
        public bool DebitAccount(Decimal amount);
        public bool CreditAccount(Decimal amount);
    }
}
