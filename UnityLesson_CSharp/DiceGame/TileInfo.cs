using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class TileInfo
    {
        public int index; // 몇번째 칸인지에 대한 번호
        public string name;
        public string discription;

        public virtual void TileEvent()
        {
            Console.WriteLine($"Tile number :{index}, The Player is On {name}, {discription}");
        }
    }
}
