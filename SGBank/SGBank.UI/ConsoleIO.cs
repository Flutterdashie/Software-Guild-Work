using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class ConsoleIO
    {
        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Balance: {account.Balance:c}");
        }

        public static bool TryParseCurrency(string input, out decimal result)
        {
            bool validNumber = decimal.TryParse(input, out result);
            if (validNumber)
            {
                return (result * 100.0M) == decimal.Truncate(result * 100.0M);
            }
            else
            {
                return validNumber;
            }
        }
    }
}
