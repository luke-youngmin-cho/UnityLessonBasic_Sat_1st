using System;

namespace UnityLesson_CSharp_delegate
{
    internal class Program
    {
        delegate int CalcDelegate(int a, int b);
        static bool doSum = false;
        static bool doSub = false;
        static bool doDiv = true;
        static void Main(string[] args)
        {
            int a = 4;
            int b = 7;

            CalcDelegate CD_Sum = Sum;
            CalcDelegate CD_Sub = Sub;
            // 람다식 : 함수를 정의하지 않고 연산에 필요한 내용만 표현하는 방법
            CalcDelegate CD_Div = delegate (int a, int b)
            {
                return a / b;
            };

            if (doSum)
            {
                PrintCalcResult(a, b, CD_Sum);
            }
            if (doSub)
            {
                PrintCalcResult(a, b, CD_Sub);
            }
            if (doDiv)
            {
                PrintCalcResult(a, b, CD_Div);
            }
            
        }
        static int Sum(int a, int b)
        {
            return a + b;
        }
        static int Sub(int a, int b)
        {
            return a - b;
        }
        static void PrintCalcResult(int a, int b, CalcDelegate calcMethod)
        {
            Console.WriteLine($"CalcResult : {calcMethod(a, b)}");
        }
    }
}
