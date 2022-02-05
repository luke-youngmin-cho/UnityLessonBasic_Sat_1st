using System;
using System.Collections.Generic;
namespace UnityLesson_CSharp_Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //------------------------------------------
            // List
            //------------------------------------------
            List<int> _list = new List<int>();
            _list.Add(3);
            _list.Add(2);
            _list.Add(1);
            _list.Add(0);
            _list.Add(3);

            // 0번째 인덱스부터 탐색하고, 첫번째로 파라미터와 같은 요소를 발견하면 삭제.
            // 삭제 성공시 true 반환, 아니면 false 반환
            _list.Remove(3);
            int length = _list.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(_list[i]);
            }
            // foreach 는 collection 이 가지고있는 타입의 아이템만큼
            // 반복문을 실행하면서 각 아이템을 반환해준다.
            foreach (int num in _list)
            {
                Console.WriteLine(num);
            }

            List<Orc> list_Orc = new List<Orc>();
            foreach (Orc item in list_Orc)
            {

            }
        }
    }
    class Orc
    {

    }
}
