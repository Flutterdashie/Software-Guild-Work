﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public static class UserIO
    {
        public static string GetStringFromUser(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.White;
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

        public static void WhiteOutput()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public static void DrawBoard(Player boardOwner)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            
            Console.WriteLine("Your attempted shots:");
            string Letters = "ABCDEFGHIJ";
            Console.Write("  ");
            for (int row1 = 1; row1 <= 10; row1++)
            {
                Console.Write(row1 + " ");
            }
            Console.WriteLine();
            for (int xCoord = 1; xCoord <= 10; xCoord++)
            {
                Console.Write(Letters.Substring(xCoord - 1, 1) + " ");
                for (int yCoord = 1; yCoord <= 10; yCoord++)
                {
                    ShotHistory coordHistory = boardOwner.Board.CheckCoordinate(new Coordinate(xCoord, yCoord));
                    switch (coordHistory)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("H ");
                            break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("M ");
                            break;
                        case ShotHistory.Unknown:
                            Console.Write("X ");
                            break;
                    }
                    Console.ForegroundColor = oldColor;
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

        public static bool InterpretTurnResult(FireShotResponse response)
        {
            bool validTurn = false;
            switch (response.ShotStatus)
            {
                case ShotStatus.Invalid:
                    Console.WriteLine("Not a valid shot location! Try again.");
                    break;
                case ShotStatus.Duplicate:
                    Console.WriteLine("That location has already been shot! Try again.");
                    break;
                case ShotStatus.Miss:
                    Console.WriteLine("Miss! Better luck next round.");
                    validTurn = true;
                    break;
                case ShotStatus.Hit:
                    Console.WriteLine("Hit! But it isn't sunk yet!");
                    validTurn = true;
                    break;
                case ShotStatus.HitAndSunk:
                    Console.WriteLine($"Hit and sunk! That was their {response.ShipImpacted}!");
                    validTurn = true;
                    break;
                case ShotStatus.Victory:
                    Console.WriteLine($"Hit and sunk! That was their {response.ShipImpacted}!");
                    Console.WriteLine("That was their last ship!");
                    validTurn = true;
                    break;
                default:
                    Console.WriteLine("The program encountered a serious error. Please try your turn again.");
                    break;
            }
            return validTurn;

        }

        public static bool GetPlayAgain()
        {
            char userReply;
            while (true)
            {
                Console.WriteLine("Would you like to play again? y/n");
                userReply = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (userReply)
                {
                    case 'y':
                    case 'Y':
                        return true;
                    case 'n':
                    case 'N':
                        return false;
                    default:
                        Console.WriteLine("Invalid entry.");
                        continue;
                }
            }
        }

    }
}