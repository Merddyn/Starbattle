using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

/*
 Number ranges: 
    100-999 is reserved for terrain
    5000-5999 is reserved for ship classes
 
 */

namespace StarBattle
{
    public enum ShipClasses
    {
        [Display(Name = "Miranda")]
        Miranda = 5001,
        [Display(Name = "Constitution")]
        Constitution = 5002,
        [Display(Name = "Oberth")]
        Oberth = 5003
    }

    public enum TileGraphics
    {
        [Display(Name = "Miranda")]
        Miranda = 5001,
        [Display(Name = "Constitution")]
        Constitution = 5002,
        [Display(Name = "Oberth")]
        Oberth = 5003,

        [Display(Name = "EmptySpace")]
        EmptySpace = 100
    }
}
