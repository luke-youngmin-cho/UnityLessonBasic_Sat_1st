using System;
// switch-case 에 적합한 형태 , 
// 각 요소들이 동시에 일어나는 경우가 없는 상황에 적합한 형태
// 특히 FSM ( Finite State Machine ).
// 
enum e_PlayerState
{
    Idle,   // ...00000000
    Attack, // ...00000001
    Jump,   // ...00000010
    Walk,   // ...00000011
    Run,    // ...00000100
    Dash,   // ...00000101
    Home,   // ...00000110
    DashAttack, // ...00000111
}
// 각 요소들이 동시에 일어나는 경우가 있는 상황에 적합한 형태
[Flags] // ToString() 속성을 참조할때 중복되는 모든 요소들에 대해 표현이 가능(문자열로 형변환이 가능)
enum e_PlayerStateFlags
{
    Idle = 0,           // ...00000000
    Attack = 1 << 0,    // ...00000001
    Jump = 1 << 1,      // ...00000010
    Walk = 1 << 2,      // ...00000100
    Run = 1 << 3,       // ...00001000
    Dash = 1 << 4,      // ...00010000
    Home = 1 << 5,      // ...00100000
}

namespace UnityLesson_CSharp_EnumAndSwitchCase
{
    internal class Program
    {
        //Casting 캐스팅
        //비트 정보 그대로 들고와서 타입만 변경시킴
        static e_PlayerState createMotion = (e_PlayerState)1234;
        static void Main(string[] args)
        {            
            Warrior warrior = new Warrior();
            Console.WriteLine("생성할 전사의 이름을 입력하세요:");
            warrior.name = Console.ReadLine();

            // if 분기
            if(createMotion == e_PlayerState.Idle)
            {
                // do nothing
            }
            else if(createMotion == e_PlayerState.Attack)
            {
                warrior.Attack();
            }
            else if(createMotion == e_PlayerState.Jump)
            {
                warrior.Jump();
            }
            else if(createMotion == e_PlayerState.Walk)
            {
                warrior.Walk();
            }
            else if(createMotion == e_PlayerState.Run)
            {
                warrior.Run();
            }
            else if(createMotion == e_PlayerState.Dash)
            {
                warrior.Dash();
            }
            else if(createMotion == e_PlayerState.Home)
            {
                warrior.Home();
            }
            else
            {
                Console.WriteLine("어 상태가 이상한데");
            }

            // switch- case 형태
            /*switch (경우의 수 매개변수)
            {
                case 경우1:
                    이 경우에 실행할 내용
                    break;
                case 경우2:
                    이 경우에 실행할 내용
                    break;
                default:
            }*/

            // Switch-case 분기

            // 전사에게 동작 명령하기
            Console.Write("전사에게 명령을 내려 주세요");
            string motionInput = Console.ReadLine();
            e_PlayerState motion;
            bool isParsed = Enum.TryParse(motionInput, out motion);
            if (isParsed)
            {
                switch (motion)
                {
                    case e_PlayerState.Idle:
                        // do nothing
                        break;
                    case e_PlayerState.Attack:
                        warrior.Attack();
                        break;
                    case e_PlayerState.Jump:
                        warrior.Jump();
                        break;
                    case e_PlayerState.Walk:
                        warrior.Walk();
                        break;
                    case e_PlayerState.Run:
                        warrior.Run();
                        break;
                    case e_PlayerState.Dash:
                        warrior.Dash();
                        break;
                    case e_PlayerState.Home:
                        warrior.Home();
                        break;
                    default:
                        Console.WriteLine("전사는 그런거 할줄 몰라요");
                        break;
                }
            }
            else
            {
                Console.WriteLine("야 입력이 이상해");
            }
            

            Console.ReadLine();
        }
    }
    public class Warrior
    {
        public string name;
        public void Attack()
        {
            Console.WriteLine($"{name} (이)가 공격함");
        }
        public void Jump()
        {
            Console.WriteLine($"{name} (이)가 점프함");
        }
        public void Walk()
        {
            Console.WriteLine($"{name} (이)가 걸음");
        }
        public void Run()
        {
            Console.WriteLine($"{name} (이)가 달림");
        }
        public void Dash()
        {
            Console.WriteLine($"{name} (이)가 돌진함"); 
        }
        public void Home()
        {
            Console.WriteLine($"{name} (이)가 귀환함");
        }

    }
}
