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
        public FileAccountRepository(string path)
        {
            string[] rows = File.ReadAllLines(path);
            _accounts = new Dictionary<string, Account>();
            foreach (string row in rows)
            {
                Account holder = FileAccountHandler.FromRow(row);
                _accounts.Add(holder.AccountNumber, holder);
            }
        }
        public Account LoadAccount(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
