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
        private readonly string _path;
        public FileAccountRepository(string path)
        {
            _path = path;
        }
        public Account LoadAccount(string AccountNumber)
        {
            string[] rows = File.ReadAllLines(_path);
            foreach (string row in rows)
            {
                if(row.Split(',')[0] == AccountNumber)
                {
                    return FileAccountHandler.FromRow(row);
                }
            }
            return null;
        }

        public void SaveAccount(Account account)
        {
            string[] rows = File.ReadAllLines(_path);

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].Split(',')[0] == account.AccountNumber)
                {
                    rows[i] = FileAccountHandler.ToRow(account);
                    break;
                }
            }
            File.WriteAllLines(_path, rows);
        }
        
    }
}
