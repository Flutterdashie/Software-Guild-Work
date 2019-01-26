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
            

            while (true)
            {
                //check whos turn it is
                UserIO.DrawBoard(Player1);
                //ask for cord for firing
                //return hit miss 
                //check if anyone won
                //clear console
                UserIO.Continue();
            }
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
