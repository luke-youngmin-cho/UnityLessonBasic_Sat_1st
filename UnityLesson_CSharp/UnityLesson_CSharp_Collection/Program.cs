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
                list_Orc.Add(item);
            }
            //------------------------------------------
            // Dictionary
            //------------------------------------------
            Dictionary<string, string> _dic = new Dictionary<string, string>();
            _dic.Add("검사", "양손대검을 사용하여 물리공격을 하는 클래스");
            _dic.Add("마법사", "지팡이를 사용하여 마법공격을 하는 클래스");
            _dic.Add("수호자", "창과 방패를 사용하여 물리공격 및 방어 위주의 클래스");
            //_dic.Remove("검사");

            bool isSwordMasterExist = _dic.ContainsKey("검사");
            if (isSwordMasterExist)
            {
                string tmpValue = _dic["검사"];
                Console.WriteLine($"검사 : {tmpValue}");
            }
            else
            {
                Console.WriteLine($"검사가 없는데요?");
            }

            // dictionary 도 foreach 구문이 가능하다.
            // dictionary 는 collection 이고
            // dictionary 에서 Keys 를 가져오면 KeyCollection 을 가져올수있고
            // dictionary 에서 Values 를 가져오면 ValueCollection 을 가져올수 있다.
            // 즉, dicionary 자체도, key, value 각각도 foreach 구문이 가능하다

            // dictionary.Keys 를  foreach 문 실행
            foreach (string sub in _dic.Keys)
            {
                string tmpValue = _dic[sub];
                Console.WriteLine($"{sub} : {tmpValue}");
            }
            // dictionary.Values 를 foreach문 실행
            foreach (string sub in _dic.Values)
            {
                Console.WriteLine(sub);
            }
            // dictionary 를 foreach 문 실행
            foreach (KeyValuePair<string,string> sub in _dic)
            {
                string tmpKey = sub.Key;
                string tmpValue = sub.Value;
                Console.WriteLine($"{tmpKey} :{tmpValue}");
                Console.WriteLine(sub);
            }

            //------------------------------------------
            // Queue ( List 와 비슷하나, FIFO , First Input First Output 체계이다 )
            //------------------------------------------
            Queue<int> _queue = new Queue<int>();

            _queue.Enqueue(10);
            _queue.Enqueue(20);
            _queue.Enqueue(30);
            Console.WriteLine(_queue.Peek());
            Console.WriteLine(_queue.Dequeue());
            Console.WriteLine(_queue.Dequeue());
            Console.WriteLine(_queue.Dequeue());
            //------------------------------------------
            // Stack ( List 와 비슷하나, LIFO, Last Input First Output 체계이다 )
            //------------------------------------------
            Stack<int> _stack = new Stack<int>();

            _stack.Push(10);
            _stack.Push(20);
            _stack.Push(30);
            Console.WriteLine(_stack.Peek());
            Console.WriteLine(_stack.Pop());
            Console.WriteLine(_stack.Pop());
            Console.WriteLine(_stack.Pop());
        }
    }
    class Orc
    {

    }
}
