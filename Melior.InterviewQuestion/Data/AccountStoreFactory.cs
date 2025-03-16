using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
