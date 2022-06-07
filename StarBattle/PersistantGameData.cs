using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBattle
{
    class PersistantGameData
    {
        public bool JustWon { get; set; }
        public LevelDescription CurrentLevel { get; set; }
        public int PlayerWon;
        public bool FirstRound = true;
        public PersistantGameData()
        {
            JustWon = false;
            PlayerWon = 0;
        }
    }
}
