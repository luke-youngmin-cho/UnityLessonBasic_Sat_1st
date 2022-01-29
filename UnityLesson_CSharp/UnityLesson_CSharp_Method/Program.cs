using System;

namespace UnityLesson_CSharp_Method
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            PrintHelloWorld();
            PrintSomething("tyurtyuytughjfgj"); // 함수 호출에서 소괄호 안 내용은 매개변수(parameter)라고 함
            bool tmpIsFinished = false;            
            tmpIsFinished = PrintSomethingAndReturnIsFinished("efsdadsfdsf");
            Console.WriteLine(tmpIsFinished);
        }
        // 인자 X, 반환 X
        static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }
        // 인자 O ,반환 X
        static void PrintSomething(string something) // 함수 정의에서 소괄호 안 내용은 인자 (Argument)
        {
            Console.WriteLine(something);
        }
        // 인자 O , 반환 O
        // something 을 콘솔창에 출력하고 true 를 반환하는함수
        static bool PrintSomethingAndReturnIsFinished(string something)
        {
            bool isFinished = false; // 함수 내에서 정의된 변수를 지역변수 라고 한다. 지역변수는 다른 함수에서 가져다 쓸 수 없다.
                                    // 해당 함수 내에서'만' 연산을 처리하기 위해서 사용
            Console.WriteLine(something);
            
            if(something == "HelloWorld")
            {
                isFinished = true;
            }
            else
            {
                isFinished = false;
            }

            return isFinished;
        }
        
        
        /*반환형 함수이름(인자(argument)자료형 인자이름, 인자자료형 인자이름 ..)  
        {
            함수 연산 내용

            return 반환할 내용
        }*/

    }
}
