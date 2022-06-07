using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Engine;
using Book_Engine.Input;
using System.Windows.Forms;
using System.Drawing;

namespace StarBattle
{
    class Level // Surprisingly, unused at present.
    {
        Input _input;
        PersistantGameData _gameData;
        PlayerCharacter _playerCharacter;
        TextureManager _textureManager;
        ScrollingBackground _background;
        ScrollingBackground _backgroundLayer;
        ScrollingBackground _backgroundLayer2;
        // List<Enemy> _enemyList = new List<Enemy>(); <= Removed
        EnemyManager _enemyManager;
        BulletManager _bulletManager = new BulletManager(new RectangleF(-1300 / 2, -750 / 2, 1300, 750));
        EffectsManager _effectsManager;

        AnimatedSprite _testSprite = new AnimatedSprite();

        public Level(Input input, TextureManager textureManager, PersistantGameData gameData)
        {
            _testSprite.Texture = textureManager.Get("explosion");
            _testSprite.SetAnimation(4, 4);

            _input = input;
            _gameData = gameData;
            _textureManager = textureManager;
            _effectsManager = new EffectsManager(_textureManager);
            

            _background = new ScrollingBackground(textureManager.Get("background"));
            _background.SetScale(2, 2);
            _background.Speed = 0.15f;

            _backgroundLayer = new ScrollingBackground(textureManager.Get("background_layer_1"));
            _backgroundLayer.Speed = 0.05f;
            _backgroundLayer.SetScale(2, 2);

            _backgroundLayer2 = new ScrollingBackground(textureManager.Get("background_layer_1"));
            _backgroundLayer2.Speed = 0.1f;
            _backgroundLayer2.SetScale(2, 2);


            _playerCharacter = new PlayerCharacter(_textureManager, _bulletManager);
            //_enemyList.Add(new Enemy(_textureManager, _effectsManager)); <= removed
            _enemyManager = new EnemyManager(_textureManager, _effectsManager, _bulletManager, _playerCharacter, -1300);
        }

        public bool HasPlayerDied()
        {
            return _playerCharacter.IsDead;
        }

        private void UpdateCollisions()
        {
            foreach(Enemy enemy in _enemyManager.EnemyList)
            {
                if (enemy.GetBoundingBox().IntersectsWith(_playerCharacter.GetBoundingBox()))
                {
                    enemy.OnCollision(_playerCharacter);
                    _playerCharacter.OnCollision(enemy);
                }

                _bulletManager.UpdateEnemyCollisions(enemy);
                _bulletManager.UpdatePlayerCollisions(_playerCharacter);
            }
        }


        public void Update(double elapsedTime, double gameTime)
        {
            _effectsManager.Update(elapsedTime);
            _testSprite.Update(elapsedTime);
            _playerCharacter.Update(elapsedTime);
            UpdateCollisions();
            _bulletManager.Update(elapsedTime);

            _background.Update((float)elapsedTime);
            _backgroundLayer.Update((float)elapsedTime);
            _backgroundLayer2.Update((float)elapsedTime);

            //_enemyList.ForEach(x => x.Update(elapsedTime)); <= remove this line
            _enemyManager.Update(elapsedTime, gameTime);

            //Input code has been moved into this method
            UpdateInput(elapsedTime);
            
        }

        private void UpdateInput(double elapsedTime)
        {
            if (_input.Keyboard.IsKeyPressed(Keys.Space) || _input.Controller.ButtonA.Pressed)
            {
                _playerCharacter.Fire();
            }
            //Get controls and apply to player character
            double _x = _input.Controller.LeftControlStick.X;
            double _y = _input.Controller.LeftControlStick.Y * -1;
            Vector controlInput = new Vector(_x, _y, 0);

            if (Math.Abs(controlInput.Length()) < 0.0001)
            {
                //If the input is very small, then the player may not be using a controller; he might be using the keyboard.
                if (_input.Keyboard.IsKeyHeld(Keys.Left))
                {
                    controlInput.X = -1;
                }

                if (_input.Keyboard.IsKeyHeld(Keys.Right))
                {
                    controlInput.X = 1;
                }

                if (_input.Keyboard.IsKeyHeld(Keys.Up))
                {
                    controlInput.Y = 1;
                }

                if (_input.Keyboard.IsKeyHeld(Keys.Down))
                {
                    controlInput.Y = -1;
                }
            }

            _playerCharacter.Move(controlInput * elapsedTime);
        }

        public void Render(Renderer renderer)
        {
            _background.Render(renderer);
            _backgroundLayer.Render(renderer);
            _backgroundLayer2.Render(renderer);

            //_enemyList.ForEach(x => x.Render(renderer)); <=Remove this line
            _enemyManager.Render(renderer);
            _playerCharacter.Render(renderer);
            _bulletManager.Render(renderer);

            renderer.DrawSprite(_testSprite);
            _effectsManager.Render(renderer);
            renderer.Render();
        }
    }

}
