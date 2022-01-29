using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_Operator
{
    static public class OperatorMethods
    {
        // 산술 연산
        //=============================================================
        // 더하기
        static public int Sum(int a, int b)
        {
            return a + b;
        }

        // 논리 연산
        //=============================================================
        static public bool LogicOr(bool A, bool B)
        {
            return A | B;
        }
    }
}
