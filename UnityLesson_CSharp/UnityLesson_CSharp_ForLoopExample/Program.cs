using System;

// Orc 객체를 10마리 만들고
// Orc 들의 인스턴스는 Orc타입 배열에 넣어준다. 
// 각 오크의 이름은 "오크0", "오크1", ... , "오크9"
// 각 오크에게 isReseting 멤버변수값은 랜덤으로 넣어준다. 
// 각 오크가 쉬고있는지 확인해서 쉬고있다면 점프하도록 한다.
namespace UnityLesson_CSharp_ForLoopExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Orc[] arr_Orc = new Orc[10];
            int length = arr_Orc.Length;
            for (int i = 0; i < length; i++)
            {
                arr_Orc[i] = new Orc();
                arr_Orc[i].name = $"오크{i}";
            }
            // isResting 랜덤 세팅
            
            for (int i = 0;i < length;i++)
            {
                arr_Orc[i].isResting = GetRandomBool();
            }
            

            for (int i = 0; i < length; i++)
            {
                if (arr_Orc[i].isResting)
                {
                    arr_Orc[i].Jump();
                }
            }
        }
        static private bool GetRandomBool()
        {
            Random random = new Random();
            int randomInt = random.Next(0, 2); // minValue ~ maxValue - 1
            bool randomBool = Convert.ToBoolean(randomInt);
            return randomBool;
        }
    }

    public class Orc
    {
        public string name;
        public float height;
        public float weight;
        public int age;
        public char genderChar;
        public bool isResting;

        public void Smash()
        {
            Console.WriteLine($"{name} (이)가 휘둘렀다");
        }
        public void Jump()
        {
            Console.WriteLine($"{name} (이)가 점프했다");
        }
    }
}
