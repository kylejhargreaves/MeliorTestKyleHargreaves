namespace Melior.InterviewQuestion.Data
{
    public interface IAccountStoreFactory
    {
        public IAccountDataStore GetAccountStore();
    }
}
