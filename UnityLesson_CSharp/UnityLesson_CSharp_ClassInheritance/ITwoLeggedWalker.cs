using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_ClassInheritance
{
    // Interface
    // 클래스랑 비슷하게 생겼지만
    // 함수, 이벤트, 인덱서, 속성(Attriburte) 만 멤버로 가질수 있고
    // 각 멤버는 접근제한자 기본적으로 public 이다 
    // 클래스와 다르게 다중상속이 가능하다. ( 한 클래스가 여러개의 인터페이스를 상속받을 수 있다 )
    // 클래스 추상화를 할 때, 여러 클래스들의 함수들이 똑같은 이름으로 필요한 경우 인터페이스로 묶어서 따로 관리할 수 있다.
    // 인터페이스를 상속받은 클래스는 
    // 인터페이스에 정의된 모든 멤버를 멤버로 가지고 있어야한다.
    // 인터페이스는 가능한 한 세분화를 많이 할수록 좋다.
    internal interface ITwoLeggedWalker
    {
        void TwoLeggedWalk();
    }
}
