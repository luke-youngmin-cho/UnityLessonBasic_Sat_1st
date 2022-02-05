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
        // 빼기
        static public int Sub(int a, int b)
        {
            return a - b;
        }
        // 나누기
        static public int Div(int a, int b)
        {
            return a / b;
        }
        // 실수형 나누기
        // 오버로드 ( overload )
        static public float Div(float a, float b)
        {
            return a / b;
        }
        // 곱하기
        static public int Mul(int a, int b)
        {
            return a * b;
        }
        // 나머지
        static public int Mod(int a, int b)
        {
            return a % b;
        }

        // 증감 연산
        //==========================================
        // 증가 연산자
        static public int Increase(int a)
        {
            a++; // 증감연산자는 해당 문장이 끝난 후에 1 증가시킴.
            return a;
        }
        // 감소 연산자
        static public int Decrease(int a)
        {
            a--;
            return a;
        }
        // 관계연산
        //==============================================
        // 같은지 비교
        static public bool IsSame(int a, int b)
        {
            return a == b;
        }
        // 다른지 비교
        static public bool IsDifferent(int a, int b)
        {
            return a != b;
        }
        // 큰지 비교
        static public bool IsBigger(int a, int b)
        {
            return a > b;
        }
        // 크거나 같은지 비교
        static public bool IsBiggerOrSame(int a, int b)
        {
            return a >= b;
        }
        // 작은지 비교
        static public bool IsSmaller(int a, int b)
        {
            return a < b;
        }
        // 작거나 같은지 비교
        static public bool IsSmallerOrSame(int a, int b)
        {
            return a <= b;
        }
        // 논리연산
        //==================================================
        // or
        static public bool LogicOR(bool A, bool B)
        {
            return A | B;
        }
        static public bool LogicAND(bool A, bool B)
        {
            return A & B;
        }
        static public bool LogicXOR(bool A, bool B)
        {
            return A ^ B;
        }
        static public bool LogicNOT(bool A)
        {
            return !A;
        }
        // 조건부 논리연산
        //=======================================================
        // or
        static public bool ConditionalLogicOR(bool A, bool B)
        {
            return A || B;
        }
        // and
        static public bool ConditionalLogicAND(bool A, bool B)
        {
            return A && B;
        }
        // 비트연산
        // ================================================
        // or
        static public int BitLogicOR(int a, int b)
        {
            return a | b;
        }
        // and
        static public int BitLogicAND(int a ,int b)
        {
            return a & b;
        }
        // xor
        static public int BitLogicXOR(int a, int b)
        {
            return a ^ b;
        }
        // not
        static public int BitLogicNOT(int a)
        {
            return ~a;
        }
        // shift - left
        static public int BitShiftLeft(int a, int howManyBitsYouWantToShift)
        {
            return a << howManyBitsYouWantToShift;
        }
        // shift - right
        static public int BitShiftRight(int a, int howManyBitsYouWantToShift)
        {
            return a >> howManyBitsYouWantToShift;
        }

    }
}
