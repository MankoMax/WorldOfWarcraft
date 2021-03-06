using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorldofWarcraft.Repositories
{
    public class AccountRepository
    {
        private string _accountBaseFolder = AppDomain.CurrentDomain.BaseDirectory + @"AccountBase\test.json";

        private List<Account> _accounts;

        public AccountRepository()
        {
            _accounts = GetAccounts();
        }

        public List<Account> GetAccounts()
        {
            var accountsJson = File.ReadAllText(_accountBaseFolder);

            if (string.IsNullOrEmpty(accountsJson))
            {
                return new List<Account>();
            }

            return JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(_accountBaseFolder));
        }

        public void SerializeAndSave()
        {
            var serializedAccounts = JsonConvert.SerializeObject(_accounts);

            File.WriteAllText(_accountBaseFolder, serializedAccounts);
        }

        public void CreateAccount(Account account)
        {
            _accounts.Add(account);

            SerializeAndSave();

            File.Create(AppDomain.CurrentDomain.BaseDirectory + @$"AccountBase\{account.Id}.json").Dispose();
        }
    }
}

