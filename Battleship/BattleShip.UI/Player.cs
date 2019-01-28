using BattleShip.BLL.GameLogic;
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
    public class Player
    {
        private Board board = new Board();
        public string Name { get; set; }

        public Player()
        {
            Name = UserIO.SetName();
            ShipSetup();
        }

        public Board Board
        {
            get
            {
                return board;
            }
        }

        private void ResetBoard()
        {
            board = new Board();
        }

        public void ShipSetup()
        {
            ResetBoard();
            UserIO.WriteLine($"Alright {Name}, let's setup your ships.");

            for (int i = 0; i < 5; i++)
            {
                UserIO.WriteLine($"Place your {Enum.GetName(typeof(ShipType), (ShipType)i)}.");

                PlaceShipRequest request = new PlaceShipRequest()
                {
                    Coordinate = UserIO.GetCoord(),
                    Direction = UserIO.GetDirection(),
                    ShipType = (ShipType)i
                };

                ShipPlacement spotValidity = board.PlaceShip(request);
                switch (spotValidity)
                {
                    case ShipPlacement.NotEnoughSpace:
                        i--;
                        UserIO.WriteLine("Not enough space to place a ship there!");
                        continue;
                    case ShipPlacement.Overlap:
                        i--;
                        UserIO.WriteLine("This spot overlaps with another ship!");
                        break;
                    case ShipPlacement.Ok:
                        UserIO.WriteLine("Ship placement works!");
                        break;
                    default:
                        break;
                }
            }
            UserIO.Continue();
        }
    }
}
