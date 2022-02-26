using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class TileInfo_Star : TileInfo
    {
        public int starValue = 3;
        public override void TileEvent()
        {
            base.TileEvent();
            starValue++;
        }
    }
}
