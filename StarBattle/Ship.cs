using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StarBattle
{
    public class Ship
    {
        public int _X;
        public int _Y;
        int _TurnRadius;
        public int _Speed;
        public int _remainingMove;
        public int _turnCooldown;
        public int _Shields;
        public int _MaxHull;
        public int _Hull;
        public int _PlayerID;
        public int _TurnID;
        public ShipClasses _ShipClass;
        public int _facing;
        public Shield _foreShield;
        public Shield _starShield;
        public Shield _aftShield;
        public Shield _portShield;
        public string _name;
        public int _evasion;
        //int PhaserDamage;
        public List<Weapon> _Weapons = new List<Weapon>();

        public Ship(int X, int Y, int Facing, int TurnRadius, int Speed, int Shields, int Hull, int PlayerID, int TurnID, ShipClasses ShipClass, string Name, int Evasion)
        {
            _X = X;
            _Y = Y;
            _TurnRadius = TurnRadius;
            _Speed = Speed;
            _Shields = Shields;
            _MaxHull = Hull;
            _Hull = Hull;
            _PlayerID = PlayerID;
            _TurnID = TurnID;
            _ShipClass = ShipClass;
            _facing = Facing;
            _remainingMove = _Speed;
            _foreShield = new Shield(Shields, this);
            _starShield = new Shield(Shields, this);
            _aftShield = new Shield(Shields, this);
            _portShield = new Shield(Shields, this);
            _evasion = Evasion;
            _name = Name;
            //PhaserDamage = 5;
            GenerateWeapons(_ShipClass);
        }
        public Ship(int X, int Y, int Facing, ShipClasses ShipClass, int PlayerID, int TurnID, string Name) // Partially implemented, not complete.
        {
            _X = X;
            _Y = Y;
            _facing = Facing;
            _ShipClass = ShipClass;
            bool FoundShip = false;
            string path = "ShipStats.xml";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            XmlReader xmlIn = XmlReader.Create(path, settings);
            if (xmlIn.ReadToDescendant("ShipClass"))
            { 
                do 
                {
                    if (xmlIn["Class"] == _ShipClass.ToString())
                    {
                        FoundShip = true;

                    }
                } while (xmlIn.ReadToDescendant("ShipClass)"));
            }
        }

        public int Turn(string Direction)
        {
            if (Direction == "Left")
            {
                _facing -= 1;
                if (_facing == -1)
                {
                    _facing = 3;
                }
            }
            else // (Direction == "Right")
            {
                _facing += 1;
                if (_facing == 4)
                {
                    _facing = 0;
                }

            }
            _turnCooldown = _TurnRadius;
            return _facing;
        }
/*
        public void Fire(Ship TargetShip)
        {
            int TargetArc = ArcMath.GetShield(this, TargetShip);
            if (TargetArc == 0)
            {
                TargetShip._foreShield.TakeDamage(PhaserDamage, "Phaser");
            }
            if (TargetArc == 1)
            {
                TargetShip._starShield.TakeDamage(PhaserDamage, "Phaser");
            }
            if (TargetArc == 2)
            {
                TargetShip._aftShield.TakeDamage(PhaserDamage, "Phaser");
            }
            if (TargetArc == 3)
            {
                TargetShip._portShield.TakeDamage(PhaserDamage, "Phaser");
            }
        }
        */
        private void GenerateWeapons(ShipClasses ShipClass)
        {
            
            if (ShipClass == ShipClasses.Miranda)
            {
                //Generate Forward Weapons
                _Weapons.Add(new Weapon(2, 5, 0, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(2, 5, 0, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(5, 10, 0, "Phaser", 4, 3, 3, this));
                _Weapons.Add(new Weapon(5, 10, 0, "Phaser", 4, 3, 3, this));
                _Weapons.Add(new Weapon(4, 5, 0, "Torpedo", 5, 4, 4, this));
                _Weapons.Add(new Weapon(4, 5, 0, "Torpedo", 5, 4, 4, this));

                //Generate Starboard Weapons
                _Weapons.Add(new Weapon(2, 5, 1, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(2, 5, 1, "Phaser", 4, 3, 2, this));


                //Generate Aft Weapons
                _Weapons.Add(new Weapon(2, 5, 2, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(2, 5, 2, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(5, 10, 2, "Phaser", 4, 3, 3, this));
                _Weapons.Add(new Weapon(5, 10, 2, "Phaser", 4, 3, 3, this));
                _Weapons.Add(new Weapon(4, 5, 2, "Torpedo", 5, 4, 4, this));
                _Weapons.Add(new Weapon(4, 5, 2, "Torpedo", 5, 4, 4, this));

                //Generate Port Weapons
                _Weapons.Add(new Weapon(2, 5, 3, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(2, 5, 3, "Phaser", 4, 3, 2, this));
                
            }
            if (ShipClass == ShipClasses.Constitution)
            {
                //Generate Forward Weapons
                _Weapons.Add(new Weapon(3, 6, 0, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(3, 6, 0, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(3, 6, 0, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(4, 5, 0, "Torpedo", 5, 4, 4, this));
                _Weapons.Add(new Weapon(4, 5, 0, "Torpedo", 5, 4, 4, this));
                _Weapons.Add(new Weapon(4, 5, 0, "Torpedo", 5, 4, 4, this));
                _Weapons.Add(new Weapon(4, 5, 0, "Torpedo", 5, 4, 4, this));

                //Generate Starboard Weapons
                _Weapons.Add(new Weapon(3, 6, 1, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(3, 6, 1, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(3, 6, 1, "Phaser", 4, 3, 2, this));

                //Generate Aft Weapons
                _Weapons.Add(new Weapon(3, 6, 2, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(3, 6, 2, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(3, 6, 2, "Phaser", 4, 3, 2, this));

                //Generate Port Weapons
                _Weapons.Add(new Weapon(3, 6, 3, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(3, 6, 3, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(3, 6, 3, "Phaser", 4, 3, 2, this));
            }

            if (ShipClass == ShipClasses.Oberth)
            {
                //Generate Forward Weapons
                _Weapons.Add(new Weapon(2, 5, 0, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(2, 5, 0, "Phaser", 4, 3, 2, this));
                _Weapons.Add(new Weapon(4, 5, 0, "Torpedo", 5, 4, 4, this));
            }
            
        }
    }
}
