using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public static class UserIO
    {
        public static string GetStringFromUser(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string result = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine("Field cannot be blank");
                    continue;
                }
                return result;
            }
        }

        public static void DisplayString(string output)
        {
            Console.WriteLine(output);
        }

        public static int LoopUntilChosen(string prompt, string[] options)
        {
            if (options.Length == 0)
            {
                return 0;
            }
            while (true)
            {
                string userInput = GetStringFromUser(prompt);
                for (int i = 0; i < options.Length; i++)
                {
                    if (options[i] == userInput)
                    {
                        return i;
                    }
                }
                Console.WriteLine("Invalid choice.");

            }
        }

        public static int GetIntFromUser(string prompt, int lowerBound = int.MinValue, int upperBound = int.MaxValue)
        {
            int output = 0;
            string result = "";
            bool isValid = false;
            while (true)
            {
                Console.WriteLine(prompt);
                result = Console.ReadLine();
                isValid = int.TryParse(result, out output);
                isValid &= output >= lowerBound;
                isValid &= output <= upperBound;
                if (isValid)
                {
                    return output;
                }
                Console.WriteLine("Invalid input. Ensure value can be represented by a 32-bit int.");
            }
        }

        public static void PrintIntList(string prompt, List<int> data)
        {
            string delimiter = "";
            Console.Write(prompt);
            foreach (int val in data)
            {
                Console.Write(delimiter + val);
                delimiter = ", ";
            }
            Console.WriteLine();
        }

        public static string BoolInserter(string firstHalf, bool test, string remainder)
        {
            string output = firstHalf;
            output += test ? "" : "not ";
            output += remainder;
            return output;
        }
    }
}
