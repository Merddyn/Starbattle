using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBattle
{
    public class Shield
    {
        public int _integrity;
        public int _maxIntegrity { get; private set; }
        Ship _ship;

        public Shield(int startIntegrity, Ship ship)
        {
            _ship = ship;
            _integrity = startIntegrity;
            _maxIntegrity = startIntegrity;
        }

        public void TakeDamage(int Damage, string Type)
        {
            _integrity -= Damage;
            if (_integrity < 0)
            {
                int Remainder = Math.Abs(_integrity);
                _ship._Hull -= Remainder;
                _integrity = 0;
            }
        }
    }
}
