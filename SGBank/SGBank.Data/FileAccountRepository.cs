using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private Dictionary<string, Account> _accounts;
        private readonly string _path;
        public FileAccountRepository(string path)
        {
            _path = path;
            string[] rows = File.ReadAllLines(_path);
            _accounts = new Dictionary<string, Account>();
            foreach (string row in rows)
            {
                Account holder = FileAccountHandler.FromRow(row);
                _accounts.Add(holder.AccountNumber, holder);
            }
        }
        public Account LoadAccount(string AccountNumber)
        {
            if(_accounts.ContainsKey(AccountNumber))
            {
                return _accounts[AccountNumber];
            }
            return null;
        }

        public void SaveAccount(Account account)
        {
            if(!_accounts.ContainsKey(account.AccountNumber))
            {
                throw new KeyNotFoundException("The account number has been changed since last load. Please contact IT");
            }
            _accounts[account.AccountNumber] = account;
            //SaveFile();
        }
        private List<Account> ReadAllAccounts()
        {
            return _accounts.Values.ToList();
        }
        private void SaveFile()
        {
            List<string> accountData = new List<string>();
            foreach (Account account in ReadAllAccounts())
            {
                accountData.Add(FileAccountHandler.ToRow(account));
            }
            File.WriteAllLines(_path, accountData);
        }
    }
}
