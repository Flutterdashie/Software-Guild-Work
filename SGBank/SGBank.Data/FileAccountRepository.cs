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

    internal static class FileAccountHandler
    {
        public static string ToRow(Account account)
        {
            string output = account.AccountNumber + ",";
            output += account.Name + ",";
            output += account.Balance.ToString() + ",";
            string accountType;
            switch (account.Type)
            {
                case AccountType.Free:
                    accountType = "F";
                    break;
                case AccountType.Basic:
                    accountType = "B";
                    break;
                case AccountType.Premium:
                    accountType = "P";
                    break;
                default:
                    accountType = "?";
                    break;
            }
            output += accountType;
            return output;

        }

        public static Account FromRow(string row)
        {
            
            string[] fields = row.Split(',');
            if(fields.Length != 4)
            {
                throw new FormatException("File is improperly formatted! Check your account file.");
            }
            Account output = new Account()
            {
                AccountNumber = fields[0],
                Name = fields[1],
                Balance = decimal.Parse(fields[2]),
            };
            switch (fields[3])
            {
                case "F":
                    output.Type = AccountType.Free;
                    break;
                case "B":
                    output.Type = AccountType.Basic;
                    break;
                case "P":
                    output.Type = AccountType.Premium;
                    break;
                default:
                    throw new FormatException("Invalid Account Type");
            }
            return output;
        }
    }
}
