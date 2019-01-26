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
        internal static object Board;
        public Board board = new Board();
        public string name { get; set; }

        public Player()
        {
            name = UserIO.SetName();
            ShipSetup();
        }

        public Board playerBoard
        {
            get
            {
                return board;
            }
        }

        public void ShipSetup()
        {
            Console.WriteLine($"Alright {name}, lets setup your ships.");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Place your {Enum.GetName(typeof(ShipType), (ShipType)i)}.");

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
                        Console.WriteLine("Not enough Space to place a ship there!");
                        continue;
                    case ShipPlacement.Overlap:
                        i--;
                        Console.WriteLine("This spot overlaps with another ship!");
                        break;
                    case ShipPlacement.Ok:
                        Console.WriteLine("Ship placement works!");
                        break;
                    default:
                        break;
                }
            }
            UserIO.Continue();
        }
    }
}
