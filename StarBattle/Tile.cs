using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Engine;

namespace StarBattle
{
    public class Tile : Entity
    {
        public TileGraphics _Contents = TileGraphics.EmptySpace;
        public int _X;
        public int _Y;
        TextureManager _textureManager;
        public int _facing;
        public string _ShipName;

        public Tile(int X, int Y, TileGraphics Contents, TextureManager textureManager, int facing)
        {
            _X = X;
            _Y = Y;
            _Contents = Contents;
            _textureManager = textureManager;
            _facing = facing;
            UpdateSprite();
            _sprite.SetScale(1.1, 1.1);
            UpdateFacing();

            _sprite.SetPosition(_X * 60, _Y * 60); // put it somewhere easy to see
        }

        public Tile(int X, int Y, TileGraphics Contents, TextureManager textureManager, int facing, string ShipName)
        {
            _X = X;
            _Y = Y;
            _Contents = Contents;
            _textureManager = textureManager;
            _facing = facing;
            UpdateSprite();
            _sprite.SetScale(1.1, 1.1);
            UpdateFacing();
            _ShipName = ShipName;

            _sprite.SetPosition(_X * 60, _Y * 60); // put it somewhere easy to see
        }

        public void UpdateGraphics()
        {
          // UpdateSprite();
           UpdateFacing();
           _sprite.SetPosition(_X * 60, _Y * 60); // put it somewhere easy to see
        }

        private void UpdateSprite()
        {
            if (_Contents == TileGraphics.Miranda)
            {
                _sprite.Texture = _textureManager.Get("Miranda");

            }
            else if (_Contents == TileGraphics.Constitution)
            {
                _sprite.Texture = _textureManager.Get("Constitution");
            }
            else if (_Contents == TileGraphics.Oberth)
            {
                _sprite.Texture = _textureManager.Get("Oberth");
            }
            else
            {
                _sprite.Texture = _textureManager.Get("bullet");
            }
        }

        private void UpdateFacing()
        {
            if (_facing == 0)
            {
                _sprite.SetRotation(Math.PI / 2); // make it face Up
            }
            else if (_facing == 1)
            {
                _sprite.SetRotation(Math.PI * 2); // make it face Right
            }
            else if (_facing == 2)
            {
                _sprite.SetRotation(Math.PI * 1.5); // make it face Down
            }
            else if (_facing == 3)
            {
                _sprite.SetRotation(Math.PI); // make it face the Left
            }
        }

        public void Render(Renderer renderer)
        {
            renderer.DrawSprite(_sprite);
        }
        
    }
}
