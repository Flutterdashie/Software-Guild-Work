using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;

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

        public static string BoolInserter(string firstHalf, bool test, string remainder)
        {
            string output = firstHalf;
            output += test ? "" : "not ";
            output += remainder;
            return output;
        }


        public static void DrawBoard(Player playName)
        {
            string Letters = "ABCDEFGHIJ";
            for (int row1 = 1; row1 <= 10; row1++) { Console.Write(row1 + " "); }
            Console.WriteLine();
            for (int x = 0; x <= 9; x++)
            {
                Console.Write(Letters.Substring(x, 1) + " ");
                for (int y = 0; y <= 9; y++)
                {
                    // Instead of x below, get the status of each cell.
                    Console.Write("x ");
                }
                Console.WriteLine();
            }
        }

        public static string SetName()
        {
            return GetStringFromUser("What is your name?");
        }

        public static void Continue()
        {
            Console.WriteLine("Press any key to continue... (Clears screen)");
            Console.ReadKey();
            Console.Clear();
        }

        public static Coordinate GetCoord()
        {
            Console.Write("Input a coordinate: ");
            string cordInput;
            char letterCoord;
            string numberCoord;
            int yCoord;
            int xCoord;

            do
            {
                cordInput = Console.ReadLine();
                if (cordInput.Length > 3 || cordInput.Length <= 1)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    letterCoord = cordInput.ToUpper().ToCharArray()[0];
                    yCoord = letterCoord - 'A' + 1;
                    if (yCoord > 10 || yCoord < 1)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    numberCoord = cordInput.Substring(1);
                    if (!int.TryParse(numberCoord, out xCoord))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    else
                    {
                        if (xCoord > 10 || xCoord < 1)
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                    }
                }
                break;
            } while (true);

            return new Coordinate(yCoord, xCoord);
        }

        public static ShipDirection GetDirection()
        {
            ConsoleKeyInfo input;
            char direction;
            do
            {
                Console.WriteLine("Input direction(W,A,S,D)");
                input = Console.ReadKey();
                Console.WriteLine();
                direction = input.KeyChar;
                switch (direction)
                {
                    case 'w':
                    case 'W':
                        return ShipDirection.Up;
                    case 'd':
                    case 'D':
                        return ShipDirection.Right;
                    case 's':
                    case 'S':
                        return ShipDirection.Down;
                    case 'a':
                    case 'A':
                        return ShipDirection.Left;
                    default:
                        Console.WriteLine("Invalid input.");
                        continue;
                }
            } while (true);

        }
    }
}
