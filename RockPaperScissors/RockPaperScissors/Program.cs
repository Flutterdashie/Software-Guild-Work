using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            int roundCount = 0;
            int[] winner; //Wins, Losses, Ties
            Random r = new Random();
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                winner = new int[3] { 0, 0, 0 }; //Ties, Wins, Losses

                if (!PromptRounds(out roundCount))
                {
                    break;
                }
                if (roundCount < 1 || roundCount > 10)
                {
                    break;
                }
                
                for (int i = 0; i < roundCount; i++)
                {
                    winner[PlayRound(r)]++;
                }
                EndingStats(winner);
                PrintResultTable(winner);



            } while (PlayAgain());

            Console.WriteLine("Goodbye!");
        }

        static bool PlayAgain()
        {
            Console.WriteLine("Would you like to play again? (Yes/No)");
            string response = Console.ReadLine().ToLower().Trim();
            if (response == "yes")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
                return false;
            }
        }

        static bool PromptRounds(out int roundCount)
        {
            Console.WriteLine("How many rounds would you like to play? Enter 1-10, or anything else to quit.");
            return int.TryParse(Console.ReadLine(), out roundCount);
        }

        static int PlayRound(Random r)
        {
            int playerChoice = 0;
            
            Console.WriteLine("If you enter something else, I\'ll pick for you! That being said...");
            Console.Write("Enter 1 for Rock, 2 for Paper, or 3 for Scissors: ");
            string playerInput = Console.ReadLine();
            if (!int.TryParse(playerInput, out playerChoice))
            {
                Console.WriteLine("I didn\'t find a number. Picking for you...");
                playerChoice = r.Next(1, 3);
            } else if(playerChoice < 1 || playerChoice > 3)
            {
                Console.WriteLine("That\'s not a valid choice. Picking for you...");
                playerChoice = r.Next(1, 3);
            }
            int compChoice = r.Next(1, 3);
            return WhoWon(playerChoice, compChoice);
        }

        static int WhoWon(int player, int computer)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Player: ");
            WriteChoice(player);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Computer: ");
            WriteChoice(computer);
            Console.ForegroundColor = ConsoleColor.White;
            //0 tie, 1 player win, 2 comp win.
            if (player == computer)
            {
                Console.WriteLine("We tied!");
                return 0;
            }
            if (player == 1)
            {
                if (computer == 2)
                {
                    Console.WriteLine("My paper beats your rock!");
                    return 2;
                } else
                {
                    Console.WriteLine("Your rock beats my scissors!");
                    return 1;
                }
            }
            if (player == 2)
            {
                if (computer == 1)
                {
                    Console.WriteLine("Your paper beats my rock!");
                    return 1;
                }
                else
                {
                    Console.WriteLine("My scissors beats your paper!");
                    return 2;
                }
            }
            if (player == 3)
            {
                if (computer == 1)
                {
                    Console.WriteLine("My rock beats your scissors!");
                    return 2;
                }
                else
                {
                    Console.WriteLine("Your scissors beats my paper!");
                    return 1;
                }
            }
            Console.WriteLine("Something broke in the code, so we\'ll call it a draw!");
            return 0;
        }

        static void WriteChoice(int choice)
        {
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Rock!");
                    break;
                case 2:
                    Console.WriteLine("Paper!");
                    break;
                case 3:
                    Console.WriteLine("Scissors!");
                    break;
                default:
                    Console.WriteLine("I think my fingers are broken!");
                    break;
            }
        }

        static void EndingStats(int[] results)
        {
            if(results.Length != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went seriously wrong. Please contact the developer.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.WriteLine("The results are in!");
            if (results[1] == results[2])
            {
                Console.WriteLine($"It\'s a tie at {results[1]} win(s) each!");
                
                return;
            } else
            {
                Console.WriteLine("The winner is....!");
                Console.Write("The ");
                int winningScore = 0;
                if(results[1] > results[2])
                {
                    Console.Write("Player");
                    winningScore = results[1];
                } else
                {
                    Console.Write("Computer");
                    winningScore = results[2];
                }
                Console.WriteLine($", with {winningScore} win(s)!");

            }
        }

        static void PrintResultTable(int[] results)
        {
            if (results.Length != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went seriously wrong. Please contact the developer.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.WriteLine("|Ties------|Player----|Computer--|");
            Console.Write("|");
            foreach(int score in results)
            {
                Console.Write("{0,-10}|",score);
            }
            Console.WriteLine();
        }
    }
}
