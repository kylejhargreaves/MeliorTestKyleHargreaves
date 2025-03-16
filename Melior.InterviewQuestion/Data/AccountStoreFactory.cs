using System.Configuration;

namespace Melior.InterviewQuestion.Data
{
    public class AccountStoreFactory : IAccountStoreFactory
    {

        public IAccountDataStore GetAccountStore()
        {
            if (ConfigurationManager.AppSettings["DataStoreType"] == "Backup")
            {
                return new BackupAccountDataStore();
            }
            else
            {
                return new AccountDataStore();
            }

        }
    }
}
