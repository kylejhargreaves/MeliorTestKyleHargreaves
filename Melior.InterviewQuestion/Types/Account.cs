namespace Melior.InterviewQuestion.Types
{
    public class Account:IAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
        public AllowedPaymentSchemes AllowedPaymentSchemes { get; set; }

        public bool CreditAccount(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public bool DebitAccount(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public bool VerifyAccount(PaymentScheme paymentScheme)
        {
            throw new System.NotImplementedException();
        }
    }
}

