using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_ClassInheritance
{
    internal class Creature : IBreather
    {
        public string DNA;
        public float age;
        public float weight;

        // virtual 키워드 : 해당 함수를 오버라이딩 가능하도록 해준다.
        // 부모클래스라고 함수라고 해서 전부 virtual 붙이는게 아니라
        // 자식클래스가 해당 함수를 재정의 해야할 때만 virutal 붙여줌
        virtual public void Breath()
        {
            age++;
        }
    }
}
