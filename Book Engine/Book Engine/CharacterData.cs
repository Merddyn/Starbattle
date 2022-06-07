using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Book_Engine
{
    public class CharacterData
    {
        
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int XOffset { get; set; }
        public int YOffset { get; set; }
        public int XAdvance { get; set; }
    }


    //CharacterData aData = _characterDictionary['a'];

}
