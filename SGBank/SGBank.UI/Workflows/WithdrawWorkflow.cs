using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class WithdrawWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter a withdrawal amount: ");
            bool validInput = decimal.TryParse(Console.ReadLine(), out decimal amount);
            AccountWithdrawResponse response;
            if (validInput)
            {
                response = accountManager.Withdraw(accountNumber, amount);
            }
            else
            {
                response = new AccountWithdrawResponse()
                {
                    Success = false,
                    Message = "Withdrawal amount was not formatted correctly"
                };
            }


            if (response.Success)
            {
                Console.WriteLine("Withdrawal completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount Withdrawn: {response.Amount:c}");
                Console.WriteLine($"New balance: {response.Account.Balance:c}");
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
