using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_Structure
{
    internal class Warrior
    {
        public Stats stats;
        public void SetStats(int STR, int DEX, int CON, int WIS, int INT, int REG)
        {
            stats._STR = STR;
            stats._DEX = DEX;
            stats._CON = CON;
            stats._WIS = WIS;
            stats._INT = INT;
            stats._REG = REG;
        }
    }    
}
