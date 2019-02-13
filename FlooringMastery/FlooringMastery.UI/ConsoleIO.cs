using FlooringMastery.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Product PickProduct(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public decimal GetArea(string prompt)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDate(string prompt)
        {
            throw new NotImplementedException();
        }

        public int GetInt(string prompt)
        {
            bool validInput = false;
            int result = 0;
            do
            {

                Console.WriteLine(prompt);
                validInput = int.TryParse(Console.ReadLine(), out result);
                if(!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }

            } while (!validInput);
            return result;
        }
    }
}
