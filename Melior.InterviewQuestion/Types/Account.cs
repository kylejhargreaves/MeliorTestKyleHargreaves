using System;

namespace Melior.InterviewQuestion.Types
{
    public class Account:IAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
        public AllowedPaymentSchemes AllowedPaymentSchemes { get; set; }

        /// <summary>
        /// The payment request has a debtor and creditor so we need to adjust both accounts accordingly
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Whether the credit has worked or not</returns>
        /// <exception cref="ArgumentException"></exception>
        public bool CreditAccount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(AccountNumber + ": Credit amount must be greater than zero.", nameof(amount)); // don't want to turn this into a debit
            }
            Balance += amount;
            return true;
        }

        /// <summary>
        /// Debit the account do some basic checks on balance and amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Whether the debit has worked or not</returns>
        /// <exception cref="ArgumentException"></exception>
        public bool DebitAccount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(AccountNumber + ": Debit amount must be greater than zero.", nameof(amount)); // the account has no money
            }

            if (Balance < amount)
            {
                return false; //they don't have enough funds
            }

            Balance -= amount;
            return true;
        }

        /// <summary>
        /// Check the account is not disabled and has schemes enabled and if it matches the passed payment scheme
        /// </summary>
        /// <param name="paymentScheme"></param>
        /// <returns>An active account with a matching payment scheme</returns>
        public bool VerifyAccount(PaymentScheme paymentScheme)
        {
            if (Status == AccountStatus.Disabled)
            {
                return false; // The account should not be disabled
            }

            if (AllowedPaymentSchemes == 0)
            {
                return false; // No schemes have been allowed
            }
          
            if (!AllowedPaymentSchemes.HasFlag(paymentScheme))
            {
                return false; // The requested payment scheme isn't available
            }

            return true;
        }
    }
}

