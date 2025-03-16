namespace Melior.InterviewQuestion.Types
{
    public class MakePaymentResult
    {
        public MakePaymentResult(bool success)
        {
            Success = success;
        }
        public MakePaymentResult() { }
        public bool Success { get; set; }
    }
}
