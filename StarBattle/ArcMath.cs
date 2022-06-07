using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBattle
{
    public static class ArcMath
    {
        public static int GetArc(Ship Attacker, Ship Target)
        {
            int RelativeX = Target._X - Attacker._X;
            int RelativeY = Target._Y - Attacker._Y;
            if (Math.Abs(RelativeX) > Math.Abs(RelativeY))
            {
                if (RelativeX > 0)
                {
                    if (Attacker._facing == 0)
                    {
                        return 1;
                    }
                    else if (Attacker._facing == 1)
                    {
                        return 0;
                    }
                    else if (Attacker._facing == 2)
                    {
                        return 3;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else 
                {
                    if (Attacker._facing == 0)
                    {
                        return 3;
                    }
                    else if (Attacker._facing == 1)
                    {
                        return 2;
                    }
                    else if (Attacker._facing == 2)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else if (Math.Abs(RelativeX) < Math.Abs(RelativeY))
            {
                if(RelativeY > 0)
                {
                    if (Attacker._facing == 0)
                    {
                        return 0;
                    }
                    else if (Attacker._facing == 1)
                    {
                        return 3;
                    }
                    else if (Attacker._facing == 2)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    if (Attacker._facing == 0)
                    {
                        return 2;
                    }
                    else if (Attacker._facing == 1)
                    {
                        return 1;
                    }
                    else if (Attacker._facing == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 3;
                    }
                }
            }
            else
            {
                if (RelativeX == 0 && RelativeY == 0)
                {
                    return 9;
                }
                else if (RelativeX > 0 && RelativeY > 0)
                {
                    if (Attacker._facing == 0)
                    {
                        return 5;
                    }
                    else if (Attacker._facing == 1)
                    {
                        return 8;
                    }
                    else if (Attacker._facing == 2)
                    {
                        return 7;
                    }
                    else
                    {
                        return 6;
                    }
                }
                else if (RelativeX > 0 && RelativeY < 0)
                {
                    if (Attacker._facing == 0)
                    {
                        return 6;
                    }
                    else if (Attacker._facing == 1)
                    {
                        return 5;
                    }
                    else if (Attacker._facing == 2)
                    {
                        return 8;
                    }
                    else
                    {
                        return 7;
                    }
                }
                else if(RelativeX < 0 && RelativeY < 0)
                {
                    if (Attacker._facing == 0)
                    {
                        return 7;
                    }
                    else if (Attacker._facing == 1)
                    {
                        return 6;
                    }
                    else if (Attacker._facing == 2)
                    {
                        return 5;
                    }
                    else
                    {
                        return 8;
                    }
                }
                else //RelativeX < 0 && RelativeY > 0
                {
                    if (Attacker._facing == 0)
                    {
                        return 8;
                    }
                    else if (Attacker._facing == 1)
                    {
                        return 7;
                    }
                    else if (Attacker._facing == 2)
                    {
                        return 6;
                    }
                    else
                    {
                        return 5;
                    }
                }
            }
        }
        public static int GetShield(Ship Attacker, Ship Target)
        {
            int RelativeX = Target._X - Attacker._X;
            int RelativeY = Target._Y - Attacker._Y;
            if (Math.Abs(RelativeX) > Math.Abs(RelativeY))
            {
                if (RelativeX > 0)
                {
                    if (Target._facing == 0)
                    {
                        return 3;
                    }
                    else if (Target._facing == 1)
                    {
                        return 2;
                    }
                    else if (Target._facing == 2)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (Target._facing == 0)
                    {
                        return 1;
                    }
                    else if (Target._facing == 1)
                    {
                        return 0;
                    }
                    else if (Target._facing == 2)
                    {
                        return 3;
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
            else if (Math.Abs(RelativeX) < Math.Abs(RelativeY))
            {
                if (RelativeY > 0)
                {
                    if (Target._facing == 0)
                    {
                        return 2;
                    }
                    else if (Target._facing == 1)
                    {
                        return 1;
                    }
                    else if (Target._facing == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    if (Target._facing == 0)
                    {
                        return 0;
                    }
                    else if (Target._facing == 1)
                    {
                        return 3;
                    }
                    else if (Target._facing == 2)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            else
            {
                if (RelativeX == 0 && RelativeY == 0)
                {
                    return 9;
                }
                else if (RelativeX > 0 && RelativeY > 0)
                {
                    if (Target._facing == 0)
                    {
                        return 7;
                    }
                    else if (Target._facing == 1)
                    {
                        return 6;
                    }
                    else if (Target._facing == 2)
                    {
                        return 5;
                    }
                    else
                    {
                        return 8;
                    }
                }
                else if (RelativeX > 0 && RelativeY < 0)
                {
                    if (Target._facing == 0)
                    {
                        return 8;
                    }
                    else if (Target._facing == 1)
                    {
                        return 7;
                    }
                    else if (Target._facing == 2)
                    {
                        return 6;
                    }
                    else
                    {
                        return 5;
                    }
                }
                else if (RelativeX < 0 && RelativeY < 0)
                {
                    if (Target._facing == 0)
                    {
                        return 5;
                    }
                    else if (Target._facing == 1)
                    {
                        return 8;
                    }
                    else if (Target._facing == 2)
                    {
                        return 7;
                    }
                    else
                    {
                        return 6;
                    }
                }
                else //RelativeX < 0 && RelativeY > 0
                {
                    if (Target._facing == 0)
                    {
                        return 6;
                    }
                    else if (Target._facing == 1)
                    {
                        return 5;
                    }
                    else if (Target._facing == 2)
                    {
                        return 8;
                    }
                    else
                    {
                        return 7;
                    }
                }
            }
        }
        public static void TestCode(Ship Attacker, Ship Target)
        {
            int RelativeX;
            int RelativeY;
            RelativeX = Target._X - Attacker._X;
            RelativeY = Target._Y - Attacker._Y;

            Console.WriteLine("A: (" + Attacker._X + ", " + Attacker._Y + ") B(" + Target._X + ", " + Target._Y + ") C: (" + RelativeX + ", " + RelativeY + ")");
        }
    }

}
