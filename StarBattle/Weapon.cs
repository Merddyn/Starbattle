using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBattle
{
    public class Weapon
    {
        int _MinDamage;
        int _MaxDamage;
        public int _Arc;
        public string _Type;
        int _Accuracy;
        int _Range;
        public int _FireRate;
        public int _CoolDown;
        Ship _ship;

        public Weapon(int MinDamage, int MaxDamage, int Arc, string Type, int Accuracy, int Range, int FireRate, Ship ship)
        {
            _MinDamage = MinDamage;
            _MaxDamage = MaxDamage;
            _Arc = Arc;
            _Type = Type;
            _Accuracy = Accuracy;
            _Range = Range;
            _FireRate = FireRate;
            _CoolDown = 0;
            _ship = ship;
        }

        public bool ToHit(int Evasion, Random r)
        {
            int HitRoll;
            HitRoll = r.Next(1, 20 + 1);
            Console.WriteLine("To-Hit: " + (HitRoll + _Accuracy));
            if(HitRoll + _Accuracy >= Evasion)
            {
                Console.WriteLine("Hit");
                return true;
            }
            else
            {
                Console.WriteLine("Miss");
                return false;
            }
        }

        public void Damage(Ship TargetShip)
        {
            Random r = new Random();
            int TargetArc = ArcMath.GetShield(_ship, TargetShip);
            int _Damage = r.Next(_MinDamage, _MaxDamage + 1);
            if (TargetArc == 0)
            {
                TargetShip._foreShield.TakeDamage(_Damage, _Type);
            }
            if (TargetArc == 1)
            {
                TargetShip._starShield.TakeDamage(_Damage, _Type);
            }
            if (TargetArc == 2)
            {
                TargetShip._aftShield.TakeDamage(_Damage, _Type);
            }
            if (TargetArc == 3)
            {
                TargetShip._portShield.TakeDamage(_Damage, _Type);
            }
            if (TargetArc == 5)
            {
                if (TargetShip._foreShield._integrity < TargetShip._starShield._integrity)
                {
                    TargetShip._starShield.TakeDamage(_Damage, _Type);
                }
                else
                {
                    TargetShip._foreShield.TakeDamage(_Damage, _Type);
                }
            }
            if (TargetArc == 6)
            {
                if (TargetShip._starShield._integrity < TargetShip._aftShield._integrity)
                {
                    TargetShip._aftShield.TakeDamage(_Damage, _Type);
                }
                else
                {
                    TargetShip._starShield.TakeDamage(_Damage, _Type);
                }
            }
            if (TargetArc == 7)
            {
                if (TargetShip._portShield._integrity < TargetShip._aftShield._integrity)
                {
                    TargetShip._aftShield.TakeDamage(_Damage, _Type);
                }
                else
                {
                    TargetShip._portShield.TakeDamage(_Damage, _Type);
                }
            }
            if (TargetArc == 8)
            {
                if (TargetShip._foreShield._integrity < TargetShip._portShield._integrity)
                {
                    TargetShip._portShield.TakeDamage(_Damage, _Type);
                }
                else
                {
                    TargetShip._foreShield.TakeDamage(_Damage, _Type);
                }
            }
            return;
        }

        public bool InRange(Ship Attacker, Ship Target)
        {

            int RelativeX = Attacker._X - Target._X;
            int RelativeY = Attacker._Y - Target._Y;
            if (_Range >= ((Math.Abs(RelativeX) + Math.Abs(RelativeY))) )
            {
                Console.Write("Attacker: " + Attacker._X + ", " + Attacker._Y);
                Console.Write("Defender: " + Target._X + ", " + Target._Y);
                Console.WriteLine("Relative: " + (RelativeX) + ", " + (RelativeY));
                Console.WriteLine("Range: " + (Math.Abs(RelativeX) + Math.Abs(RelativeY)) + ", MaxRange:" + _Range);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Attack(Ship Target, Random r)
        {
            int Arc = ArcMath.GetArc(_ship, Target);
            if ((Arc == _Arc) || ((Arc == 5) && (_Arc == 0 || _Arc == 1)) || ((Arc == 6) && (_Arc == 1 || _Arc == 2)) || ((Arc == 7) && (_Arc == 2 || _Arc == 3)) || ((Arc == 8) && (_Arc == 3 || _Arc == 0)))
            {
                AttackStep2(Target, r);
            }
        }
        public void AttackStep2(Ship Target, Random r)
        {
            if (InRange(_ship, Target))
            {
                if (_CoolDown == 0)
                {
                    _CoolDown = _FireRate;
                    if (ToHit(Target._evasion, r))
                    {
                        Damage(Target);
                    }
                }
            }
        }
    }
}
