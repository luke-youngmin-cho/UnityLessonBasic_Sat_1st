using System;
using System.Collections.Generic;

namespace UnityLesson_CSharp_ClassInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Creature creature = new Creature();
            for (int i = 0; i < 10; i++)
            {
                creature.Breath();
            }
            Console.WriteLine(creature.age);

            Human human = new Human();
            for (int i = 0; i < 10; i++)
            {
                human.Breath();
            }
            Console.WriteLine($"age : {human.age}, height : {human.height}, weight : {human.weight}");

            Dog dog = new Dog();
            dog.tailLength = 1f;

            // 각 인종20명 , 두발로 걷기
            //--------------------------------------------------------
            // case : 각 인종에 대한 리스트 별개로 생성하기
            List<WhiteMan> whiteMen = new List<WhiteMan>();
            List<BlackMan> blackMen = new List<BlackMan>();
            List<YellowMan> yellowMen = new List<YellowMan>();
            for (int i = 0; i < 20; i++)
            {
                WhiteMan tmpMan = new WhiteMan();
                whiteMen.Add(tmpMan);
            }
            for (int i = 0;i < 20; i++)
            {
                BlackMan tmpMan = new BlackMan();
                blackMen.Add(tmpMan);
            }
            for (int i = 0; i < 20; i++)
            {
                YellowMan tmpMan = new YellowMan();
                yellowMen.Add(tmpMan);
            }

            foreach (var item in whiteMen)
            {
                item.TwoLeggedWalk();
            }
            foreach(var item in blackMen)
            {
                item.TwoLeggedWalk();
            }
            foreach (var item in yellowMen)
            {
                item.TwoLeggedWalk();
            }

            // WhiteMan 객체화 -> Human 으로 인스턴스화 
            // Human변수 에 있는 Breath 를 호출하면 WhiteMan 에 있는 Breath 가 호출됨
            // 
            // 자식 객체를 부모 클래스타입으로 인스턴스화 시키고
            // 해당 변수의 virtual 멤버 함수를 호출하면 
            // 자식 객체의 override 된 함수가 호출된다.
            Human testHuman = new WhiteMan();
            testHuman.Breath();
            Console.WriteLine($"{testHuman.height}{testHuman.weight}");

            // case : 위 성질을 이용하여 부모클래스(Human) 리스트 하나만 생성
            List<Human> humen = new List<Human>();
            for (int i = 0; i < 20; i++)
            {
                Human tmpHuman1 = new WhiteMan();
                humen.Add(tmpHuman1);
                Human tmpHuman2 = new BlackMan();
                humen.Add(tmpHuman2);
                Human tmpHuman3 = new YellowMan();
                humen.Add(tmpHuman3);
            }
            foreach (var item in humen)
            {
                item.TwoLeggedWalk();
            }
*/
            WhiteMan whiteMan = new WhiteMan();
            // 인터페이스 인스턴스화 예시
            ITwoLeggedWalker iTwoLeggedWalker = new WhiteMan();
            iTwoLeggedWalker.TwoLeggedWalk();
            // case : 인터페이스로 인스턴스화 시키는 방법
            List<ITwoLeggedWalker> walkers = new List<ITwoLeggedWalker>();
            for (int i = 0; i < 20; i++)
            {
                ITwoLeggedWalker tmpWalker1 = new WhiteMan();
                walkers.Add(tmpWalker1);
                ITwoLeggedWalker tmpWalker2 = new BlackMan();
                walkers.Add(tmpWalker2);
                ITwoLeggedWalker tmpWalker3 = new YellowMan();
                walkers.Add(tmpWalker3);
            }
            foreach (var item in walkers)
            {
                item.TwoLeggedWalk();
            }

            
        }
    }
}
