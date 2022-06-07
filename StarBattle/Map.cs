using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Engine;

namespace StarBattle
{
    public class Map
    {
        public List<Tile> _TileList = new List<Tile>();
        TextureManager _textureManager;
        List<Ship> _AllShips;

        public List<Tile> TileList
        {
            get
            {
                return _TileList;
            }
        }

        public Map(TextureManager textureManager, List<Ship> AllShips)
        {
            _AllShips = AllShips;
            _textureManager = textureManager;

            
            for (int i = -5; i <= 5; i++)
            {
                for (int j = -5; j <= 5; j++)
                {
                    {
                        _TileList.Add(new Tile(i, j, TileGraphics.EmptySpace, _textureManager, 0));
                    }
                }
            }
            foreach(Ship ship in _AllShips)
            {
                _TileList.Add(new Tile(ship._X, ship._Y, (TileGraphics)ship._ShipClass, _textureManager, ship._facing, ship._name));
            }
        }

     /*  public void Update()
        {
            
            foreach (Ship ship in _AllShips)
            {
                var i = _TileList.FindIndex(x => x._X == ship._X && x._Y == ship._Y && x._Contents == ship._ShipClass);    
                _TileList.RemoveAt(i);
                _TileList.Add(new Tile(ship._X, ship._Y, ship._ShipClass, _textureManager, ship._facing));
            }
        }
       */ 
        public void MoveShip(Ship ship, int X, int Y)
        {
            var i = _TileList.FindIndex(x => x._X == ship._X && x._Y == ship._Y && x._Contents == (TileGraphics)ship._ShipClass);
            //_TileList[i]._Contents = "Blank";
            //_TileList[i].UpdateGraphics();
            ship._X += X;
            ship._Y += Y;
            ship._turnCooldown -= 1;
            if (ship._turnCooldown < 0)
            {
                ship._turnCooldown = 0;
            }
            if (ship._X > 5)
            {
                ship._X = 5;
            }
            if (ship._X < -5)
            {
                ship._X = -5;
            }
            if (ship._Y > 5)
            {
                ship._Y = 5;
            }
            if (ship._Y < -5)
            {
                ship._Y = -5;
            }
            _TileList[i]._X = ship._X;
            _TileList[i]._Y = ship._Y;
            //i = TileList.FindIndex(x => x._X == ship._X && x._Y == ship._Y);
            //_TileList[i]._Contents = ship._ShipClass;
            //    _TileList[i].UpdateGraphics();
        //    Update();
        }

        public void Render(Renderer renderer)
        {
            _TileList.ForEach(x => x.Render(renderer));
        }

        public void DisplayMap()
        {
            foreach(Tile tile in _TileList)
            {
                if (tile._Y == 5)
                {
                    Console.WriteLine(tile._Contents);
                }
                else
                {
                    Console.Write(tile._Contents);
                }
            }
        }
        

    }
}
