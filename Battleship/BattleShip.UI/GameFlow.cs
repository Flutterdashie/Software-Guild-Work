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
            bool playAgain = true;
            UserIO.WhiteOutput();
            do
            {
                bool playerTwoFirst = (rand.Next(0, 2) == 1);
                HandleGame(playerTwoFirst);
                playAgain = UserIO.GetPlayAgain();
                if(playAgain)
                {
                    //Reset ships without asking for names again
                    Player1.ShipSetup();
                    Player2.ShipSetup();
                    continue;
                }

            } while (playAgain);
            UserIO.WriteLine("Thanks for playing! Goodbye!");
        }

        public void HandleGame(bool playerTwoFirst)
        {
            Player[] players = new Player[3] { Player1, Player2, Player1 };
            int whoseTurn = playerTwoFirst ? 1 : 0 ;
            while (HandlePlayerTurn(players[whoseTurn],players[whoseTurn+1]))
            {
                whoseTurn++;
                whoseTurn %= 2;
                UserIO.Continue();
            }
            UserIO.WriteLine($"Congratulations on your victory, {players[whoseTurn].Name}!");

        }

        public FireShotResponse TryPlayerAttack(Player currentPlayer, Player enemyPlayer)
        {
            UserIO.WriteLine($"{currentPlayer.Name}, your turn!");
            UserIO.DrawBoard(enemyPlayer);
            UserIO.WriteLine("Where would you like to fire?");
            Coordinate aimingAt = UserIO.GetCoord();
            return enemyPlayer.Board.FireShot(aimingAt);
        }

        public bool HandlePlayerTurn(Player currentPlayer, Player enemyPlayer)
        {
            FireShotResponse turnResult;
            bool shouldGameContinue;
            do
            {
                turnResult = TryPlayerAttack(currentPlayer, enemyPlayer);
            } while (!UserIO.InterpretTurnResult(turnResult));
            shouldGameContinue = (turnResult.ShotStatus != ShotStatus.Victory);
            return shouldGameContinue;
        }
    }
}
