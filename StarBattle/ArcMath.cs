﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBattle
{
    public static class ArcMath
    {
        public static double getBearing(Ship Self, Ship Target)
        {
            double relativeX;
            double relativeY;
            double bearing;
            relativeX = Self._X - Target._X;
            relativeY = Self._Y - Target._Y;
            double trigAngle = Math.Atan2(relativeY, relativeX) * (180 / Math.PI);
            // Convert the trigonometric angles (0 degrees = right, increase counterclockwise) to bearing angles (0 degrees = forward/up, increase clockwise)
            if (trigAngle < 0)
                trigAngle = 360 + trigAngle;
            bearing = (trigAngle + 90) % 360;
            bearing = (360 - bearing) % 360; // Extra % 360 to get 0 degrees instead of 360 degrees. Removing from previous step gives a -45 degree top-left.

            // Adjust bearing based off of ships heading (facing).
            bearing = (bearing - (Self._facing * 90)) % 360;
            bearing = (360 + bearing) % 360;
            return bearing;
        }

        public static int GetArc(Ship Attacker, Ship Target)
        {
            int returnValue;
            if (Target._X == Attacker._X && Target._Y == Attacker._Y)
            {
                returnValue = 9;
            }
            else
            {
                double bearing = getBearing(Attacker, Target);
                if (bearing > 315 || bearing < 45)
                {
                    returnValue = 0;
                }
                else if (bearing == 45)
                    returnValue = 5;
                else if (bearing > 45 && bearing < 135)
                    returnValue = 1;
                else if (bearing == 135)
                    returnValue = 6;
                else if (bearing > 135 && bearing < 225)
                    returnValue = 2;
                else if (bearing == 225)
                    returnValue = 7;
                else if (bearing > 225 && bearing < 315)
                    returnValue = 3;
                else if (bearing == 315)
                    returnValue = 8;
                else // should be impossible, but could fit the criteria of forward
                    returnValue = 0;
            }
            System.Diagnostics.Debug.WriteLine("Firing Arc: (" + returnValue + ")");

            return returnValue;
            /*
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
            */
        }
        public static int GetShield(Ship Attacker, Ship Target)
        {



            int RelativeX = Target._X - Attacker._X;
            int RelativeY = Target._Y - Attacker._Y;

            int returnValue;
            if (Target._X == Attacker._X && Target._Y == Attacker._Y)
            {
                returnValue = 9;
            }
            else
            {
                double bearing = getBearing(Target, Attacker);
                if (bearing > 315 || bearing < 45)
                {
                    returnValue = 0;
                }
                else if (bearing == 45)
                    returnValue = 5;
                else if (bearing > 45 && bearing < 135)
                    returnValue = 1;
                else if (bearing == 135)
                    returnValue = 6;
                else if (bearing > 135 && bearing < 225)
                    returnValue = 2;
                else if (bearing == 225)
                    returnValue = 7;
                else if (bearing > 225 && bearing < 315)
                    returnValue = 3;
                else if (bearing == 315)
                    returnValue = 8;
                else // should be impossible, but could fit the criteria of forward
                    returnValue = 0;
            }
            System.Diagnostics.Debug.WriteLine("Shield Arc: (" + returnValue + ")");

            return returnValue;

            /*
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
            } */
        }
        public static void TestCode(Ship Attacker, Ship Target)
        {
            double RelativeX;
            double RelativeY;
            RelativeX = Target._X - Attacker._X;
            RelativeY = Target._Y - Attacker._Y;
            double bearing = getBearing(Target, Attacker);
            System.Diagnostics.Debug.WriteLine("A: (" + Attacker._X + ", " + Attacker._Y + ") B(" + Target._X + ", " + Target._Y + ") C: (" + RelativeX + ", " + RelativeY + ")");
            System.Diagnostics.Debug.WriteLine("Arctan: (" + Math.Atan2(RelativeY, RelativeX) + ")" + " Degrees: (" + bearing + ")" + " Facing: (" + GetShield(Attacker, Target) + ")" );
        }
    }

}
