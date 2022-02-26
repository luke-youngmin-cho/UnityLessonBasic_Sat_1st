using System;
using System.Threading;
/*
프로그램 시작시
말 다섯마리를 만들고
각 다섯마리는 초당 10~20 (정수형) 범위 거리를 랜덤하게 움직임
각각의 말이 거리 200 에 도달하면 말의 이름과 등수를 출력해줌

말은
이름, 달린거리 를 멤버변수로
달리기 를 멤버 함수로 가짐.
달리기 멤버함수는 입력받은 거리를 달린거리에 더해주어서 달린거리를 누적시키는 역할을 함.

매초 달릴 때 마다 각 말들이 얼마나 거리를 이동했는지 콘솔창에 출력해줌.
경주가 끝나면 1,2,3,4,5 등 말의 이름을 등수 순서대로 콘솔창에 출력해줌.

System.Threading namespace 에 있는 Thread.Sleep(1000); 를 사용하면 현재 프로그램을 1초 지연시킬수 있음
While 반복문에서 Thread.Sleep(1000); 을 추가하면 1초에 한번씩 반복문을 실행함.
*/
namespace HorseRacing
{
    
    internal class Program
    {
        static Random random; // 말의 달리는 속도를 랜덤하게 생성하기 위한 변수
        static bool isGameFinished = false; // 경주가 끝났는지 체크하는 변수
        static int minSpeed = 10;
        static int maxSpeed = 20;
        static int finishDistance = 200;
        static void Main(string[] args)
        {
            Horse[] arr_horse = new Horse[5]; // 말 5마리 배열
            string[] arr_FinishedHorseName = new string[5]; // 결승점 통과한 말들의 이름 
            int currentGrade = 1; //현재 등수

            // 말 생성 및 초기화
            int length = arr_horse.Length;
            for (int i = 0; i < length; i++)
            {
                arr_horse[i] = new Horse(); // 말 인스턴스화
                arr_horse[i].name = $"경주마{i + 1}"; // 말의 이름 초기화
            }
            Console.WriteLine("시작하려면 엔터를 누르세요");
            Console.ReadLine();
            Console.WriteLine("경주 시작 !");
            int count = 0;
            while (isGameFinished == false) //게임이 끝날때 까지 돌아가는 반복문
            {
                Thread.Sleep(1000); // 1초 지연
                count++;
                Console.WriteLine($"==================== {count} 초 ====================");
                // 랜덤한 속도로 말을 달리는 반복문
                for (int i = 0; i < length; i++) 
                {
                    if (arr_horse[i].available)
                    {
                        random = new Random(); // 난수 인스턴스화
                        int tmpMoveDistance = random.Next(minSpeed, maxSpeed + 1); // 랜덤 속도 생성
                        arr_horse[i].Run(tmpMoveDistance); // i 번째 말을 10~20 사이 거리만큼 움직임.
                        Console.WriteLine($"{arr_horse[i].name} (이)가 달린거리 : {arr_horse[i].distance}");
                        // 결승점 도착 체크
                        if (arr_horse[i].distance >= finishDistance)
                        {
                            arr_FinishedHorseName[currentGrade - 1] = arr_horse[i].name;
                            arr_horse[i].available = false;
                            currentGrade++;
                        }
                    }                    
                }
                Console.WriteLine("================================================");
                //경주 끝났는지 체크 (모든 말이 들어왔는지)
                if (currentGrade > length)
                {
                    isGameFinished = true;
                    Console.WriteLine("경주 끝!");
                }
            }

            Console.WriteLine("==================== 결과 발표 ====================");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"{i + 1} 등 : {arr_FinishedHorseName[i]}");
            }
            Console.WriteLine("종료하려면 엔터를 누르세요");
            Console.ReadLine();
        }
    }
}
