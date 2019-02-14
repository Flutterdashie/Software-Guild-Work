using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class ConsoleIO : IUserIO
    {
        public void WriteLine(string line) => Console.WriteLine(line);
        public void Write(string value) => Console.Write(value);

        public MenuChoice GetMenuChoice()
        {
            int userChoice = 0;
            bool validChoice = false;
            DisplayMenu();
            do
            {
                userChoice = GetInt("Enter a menu choice, 1-5");
                validChoice = userChoice <= 5 && userChoice >= 1;
            } while (!validChoice);
            //TODO: maybe make this nicer to the user I guess
            return (MenuChoice)userChoice;
        }

        public Product PickProduct(IEnumerable<Product> products)
        {

            string productFormat = "{0,-20} | {1,12:C} | {2,12:C}";
            string userInput;

            do
            {

                Console.ResetColor();
                Console.WriteLine(productFormat, "Description", "$/sqft", "Labor $/sqft");
                foreach (Product product in products)
                {
                    Console.WriteLine(productFormat, product.ProductType, product.CostPerSquareFoot, product.LaborCostPerSquareFoot);
                }
                Console.WriteLine("Please enter the desired product:");
                userInput = Console.ReadLine();
                //Slight shortcut, just prevents me writing this mess out in both lines. Probably not a good idea, but nice proof of concept.
                bool MatchesName(Product p) => p.ProductType.Equals(userInput, StringComparison.CurrentCultureIgnoreCase);
                if (products.Count(MatchesName) == 1)
                {
                    return products.First(MatchesName);
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid product. Please try again.");
            } while (true);
        }

        public decimal GetArea(string prompt)
        {
            bool validInput = false;
            decimal result = 0;
            do
            {

                Console.WriteLine(prompt);
                validInput = decimal.TryParse(Console.ReadLine(), out result);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid decimal.");
                }
                else if (result < 100)
                {
                    Console.WriteLine("Invalid input. Minimum order size is 100 square feet.");
                    validInput = false;
                }

            } while (!validInput);
            return result;
        }

        public DateTime GetDate(string prompt)
        {
            bool validInput = false;
            DateTime result;
            do
            {

                Console.WriteLine(prompt);
                validInput = DateTime.TryParse(Console.ReadLine(), CultureInfo.GetCultureInfo("en-us"), DateTimeStyles.NoCurrentDateDefault, out result);
                if (!validInput)
                {
                    Console.WriteLine("Invalid formatting. Please enter a valid date using a recognizable format, such as MM/DD/YYYY.");
                }
                else if (result.Year < 2010)
                {
                    Console.WriteLine("Please specify a date. Note that no orders were placed or can be placed before 2010.");
                    validInput = false;
                }

            } while (!validInput);
            return result.Date;
        }

        public int GetInt(string prompt)
        {
            bool validInput = false;
            int result = 0;
            do
            {

                Console.WriteLine(prompt);
                validInput = int.TryParse(Console.ReadLine(), out result);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive integer.");
                }
                else if (result < 1)
                {
                    Console.WriteLine("Integer must be positive.");
                    validInput = false;
                }

            } while (!validInput);
            return result;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void WaitForUser(string prompt)
        {
            WriteLine(prompt);
            Console.ReadKey();
        }

        public bool GetBool(string prompt)
        {
            string userIn;
            while (true)
            {
                Console.Write(prompt);
                Console.Write(" (y/n): ");
                userIn = Console.ReadLine().Trim().ToLower();
                if (userIn.Equals("y") || userIn.Equals("yes"))
                {
                    return true;
                }
                if (userIn.Equals("n") || userIn.Equals("no"))
                {
                    return false;
                }
                Console.WriteLine("Invalid response. Note that \"yes\" and \"no\" are also valid, and input is not case-sensitive.");
            }
        }

        public State GetState(string prompt, IEnumerable<State> validStates)
        {
            do
            {
                Console.WriteLine(prompt);
                string userIn = Console.ReadLine().Trim();
                var query = from s in validStates
                            where s.StateAbbr.Equals(userIn, StringComparison.CurrentCultureIgnoreCase) || s.StateName.Equals(userIn, StringComparison.CurrentCultureIgnoreCase)
                            select s;
                if (query.Count() != 1)
                {
                    Console.WriteLine("Invalid input. State is either nonexistant, or not currently available for sales.");
                    continue;
                }
                else
                {
                    return query.First();
                }
            } while (true);

        }

        public string GetString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public void DisplayMenu()
        {
            Console.WriteLine(new string('*', 27));
            Console.WriteLine("* Flooring Program");
            Console.WriteLine("*");
            Console.WriteLine("* 1. Display Orders");
            Console.WriteLine("* 2. Add an Order");
            Console.WriteLine("* 3. Edit an Order");
            Console.WriteLine("* 4. Remove an Order");
            Console.WriteLine("* 5. Quit");
            Console.WriteLine("*");
            Console.WriteLine(new string('*', 27));
        }

    }
}

