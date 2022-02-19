using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_ClassInheritance
{
    internal class BlackMan : Human
    {
        public override void Breath()
        {
            age++;
            height += 0.0006f;
            weight += 0.0003f;
        }
    }
}
