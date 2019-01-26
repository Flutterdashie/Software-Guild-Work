using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class GameFlow
    {
        Player Player1;
        Player Player2;
        public GameFlow()
        {
            Player1 = new Player();
            Player2 = new Player();
        }

        public void Run()
        {
            Random rand = new Random();

            do
            {
                bool playerTwoFirst = (rand.Next(0, 2) == 1);
                HandleGame(playerTwoFirst);
            } while (UserIO.GetPlayAgain());
        }

        public void HandleGame(bool playerTwoFirst)
        {
            Player[] players = new Player[2] { Player1, Player2 };
            int whoseTurn = playerTwoFirst ? 1 : 0 ;
            while (HandlePlayerTurn(players[whoseTurn]))
            {
                whoseTurn++;
                whoseTurn %= 2;
                UserIO.Continue();
            }
            Console.WriteLine($"Congratulations on your victory, {players[whoseTurn].Name}!");

        }

        public FireShotResponse TryPlayerAttack(Player currentPlayer)
        {
            Console.WriteLine($"{currentPlayer.Name}, your turn!");
            UserIO.DrawBoard(currentPlayer);
            Console.WriteLine("Where would you like to fire?");
            Coordinate aimingAt = UserIO.GetCoord();
            return currentPlayer.Board.FireShot(aimingAt);
        }

        public bool HandlePlayerTurn(Player currentPlayer)
        {
            FireShotResponse turnResult;
            bool shouldGameContinue;
            do
            {
                turnResult = TryPlayerAttack(currentPlayer);
            } while (!UserIO.InterpretTurnResult(turnResult));
            shouldGameContinue = (turnResult.ShotStatus != ShotStatus.Victory);
            return shouldGameContinue;
        }
    }
}
