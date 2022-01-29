using System;

namespace UnityLesson_CSharp_ClassIncludingVariablesFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        // Camel case 
        // 단어가 바뀔때 첫 문자는 대문자로한다.
        // 변수는 소문자로 시작한다.
        // class, method, namespace 등은 대문자로 시작한다.
        
        // 코드 작성시 유의사항
        // 줄임말은 되도록 사용하지 않는다. 
        // 이름을 보았을 때 어떤 기능이나 목적인지 알 수 있도록 선정한다.
        // 애매하거나 복잡한 내용이 있으면 주석을 달아준다. 
        // 띄어쓰기를 꼭 써야하는 경우 under bar (_) 를 사용한다.

        // 클래스 정의 형태
        /*class 클래스이름
        {
            멤버 변수 
            멤버 함수
        }*/

        class Person
        {
            int age;
            float height;
            bool isResting;
            char genderChar;
            string name;

            void SayAll_Info()
            {
                SayAge();
                SayHeight();
                SayIsResting();
                SayGenderChar();
                SayName();
            }
            void SayAge()
            {
                Console.WriteLine(age);
            }
            void SayHeight()
            {
                Console.WriteLine(height);
            }
            void SayIsResting()
            {
                Console.WriteLine(isResting);
            }
            void SayGenderChar()
            {
                Console.WriteLine(genderChar);
            }
            void SayName()
            {
                Console.WriteLine(name);
            }
        }
    }
}
