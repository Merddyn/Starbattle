using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Engine;

namespace StarBattle
{
    public class PlayerCharacter : Entity // Currently unused!
    {
        double _speed = 512; // pixels per second
        bool _dead = false;
        BulletManager _bulletManager;
        Texture _bulletTexture;

        public bool IsDead
        {
            get
            {
                return _dead;
            }
            
        }

        public PlayerCharacter(TextureManager textureManager, BulletManager bulletManager)
        {
            _bulletManager = bulletManager;
            _bulletTexture = textureManager.Get("bullet");
            _sprite.Texture = textureManager.Get("player_ship");
            _sprite.SetScale(0.5, 0.5);  // Spaceship is quite big scale it down.
        }

        public void Move (Vector amount)
        {
            amount *= _speed;
            _sprite.SetPosition(_sprite.GetPosition() + amount);
        }

        internal void OnCollision(Enemy enemy)
        {
            _dead = true;
        }

        internal void OnCollision(Bullet bullet)
        {
            _dead = true;
        }

        Vector _gunOffset = new Vector(55, 0, 0);
        static readonly double FireRecovery = 0.25;
        double _fireRecoveryTime = FireRecovery;
        public void Fire()
        {
            if (_fireRecoveryTime > 0)
            {
                return;
            }
            else
            {
                _fireRecoveryTime = FireRecovery;
            }
            Bullet bullet = new Bullet(_bulletTexture);
            bullet.SetColor(new Color(0, 1, 0, 1));
            bullet.SetPosition(_sprite.GetPosition() + _gunOffset);
            _bulletManager.Shoot(bullet);
        }

        public void Update(double elapsedTime)
        {
            _fireRecoveryTime = Math.Max(0, (_fireRecoveryTime - elapsedTime));
        }

        public void Render(Renderer renderer)
        {
            Render_Debug();
            renderer.DrawSprite(_sprite);
        }

        public Vector GetPosition()
        {
            return _sprite.GetPosition();
        }

    }
}
