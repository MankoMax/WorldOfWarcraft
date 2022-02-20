using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WorldOfWarcraft.Repositories;

namespace WorldOfWarcraft.Managers
{
    class AccountManager
    {
        private AccountRepository _accountRepository;
        private CharacterRepository _characterRepository;

        public AccountManager()
        {
            _accountRepository = new AccountRepository();
            _characterRepository = new CharacterRepository();
        }

        public Account TryToCreateUserAccount(string userName, string password, string passwordToConfirm)
        {
            if (!password.Equals(passwordToConfirm))
            {
                return null;
            }

            var account = new Account
            {
                UserName = userName,
                Password = password
            };

            _accountRepository.CreateAccount(account);

            return account;
        }

        public void TryToLogin(string userName, string password, out Account account)
        {
            var accounts = _accountRepository.GetAccounts();

            account = accounts
                .Where(a => a.UserName.Equals(userName) && a.Password.Equals(password))
                .FirstOrDefault();
        }

        public void AddCharacterToAccount(Guid accountId, Character character)
        {
            _characterRepository.CreateCharacter(accountId, character);
        }

        public List<Character> GetCharactersList(Guid accountId)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @$"AccountBase\{accountId}.json";
            var charactersJson = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<Character>>(charactersJson);
        }
    }
}
