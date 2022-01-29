using System;

namespace UnityLesson_CSharp_StaticExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Orc orc1 = new Orc();
            orc1.name = "오크";
            orc1.height = 240.0f;
            orc1.isResting = true;
            orc1.genderChar = '남';
            orc1.age = 30;

            orc1.Jump();
            orc1.Smash();

            Orc.typeName = "오크타입";
            Orc.SayTypeName();
        }
    }

    public class Orc
    {
        static public string typeName;
        public int age;
        public float height;
        public bool isResting;
        public char genderChar;
        public string name;

        static public void SayTypeName()
        {
            Console.WriteLine(typeName);
        }
        public void Jump()
        {
            Console.WriteLine($"{name} (이)가 점프했다");
        }
        public void Smash()
        {
            Console.WriteLine($"{name} (이)가 휘둘렀다");
        }
    }

    static public class Person
    {
    }
}
