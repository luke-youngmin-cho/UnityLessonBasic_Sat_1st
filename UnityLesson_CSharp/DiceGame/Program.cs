using System;
using System.Collections.Generic;
/*
엔터키 입력으로 주사위를 굴립니다.
주사위를 굴리면 플레이어가 전진하고, 샛별칸에 도착하거나 지나갈 시 샛별에 대한 이벤트가 발생합니다.
총 칸은 1에서 20까지 있으며, 20을 넘어가면 다시 1부터 전진을 계속합니다.
5배수 칸은 샛별칸이고, 이 칸을 지나거나 도착하면 샛별을 획득할 수 있습니다.
5배수 칸에 도착할 때에는 샛별 획득 개수가 영구적으로 1 증가합니다.
샛별을 획득할 시 , 새로 얻은 샛별 수와 총 획득한 샛별 수를 보여줍니다.

콘솔 출력 :
주사위를 돌려서 어떤 칸에 도착하면,
해당 칸의 번호 (1~20 중 하나 ), 해당 칸이 어떤칸인지 (그냥 일반인지 샛별인지 ),
현재 샛별수는 몇개인지 , 남은 주사위 수는 몇개인지 콘솔창에 출력해주고
다시 주사위를 굴리라고 콘솔창에 출력해줌.
주사위를 다쓰면 모은 샛별 수를 출력해주고 게임을 종료함. (초기 주사위 갯수 20개)

### - Hint

만들어야 하는 클래스 :
TileMap(맵을 세팅하고 맵에대한 정보를 가지고 있을 클래스)
TileInfo(각 칸들의 정보를 멤버로 가지는 클래스)
TileInfo_Star(샛별칸을 위한 클래스.TileInfo 를 상속받고 샛별칸에 대한 특수 정보를 멤버로 추가함)
주사위는 아래처럼 콘솔창에 찍어서 보여주면 됨.
Console.WriteLine("┌───────────┐");
Console.WriteLine("│ ●      ●│");
Console.WriteLine("│           │");
Console.WriteLine("│     ●    │");
Console.WriteLine("│           │");
Console.WriteLine("│ ●      ●│");
Console.WriteLine("└───────────┘");
*/
namespace DiceGame
{
    internal class Program
    {
        static private int totalTile = 20; // 총 칸의 갯수
        static private int totalDiceNumber = 20; // 총 주사위 갯수
        static private Random random;

        static void Main(string[] args)
        {
            int previousTileIndex = 0; // 이전 칸의 인덱스
            int currentTileIndex = 0; // 현재 칸의 인덱스
            int currentStarPoint = 0; // 현재 샛별 점수

            TileMap map = new TileMap();
            map.MapSetup(totalTile); // 맵 생성

            int currentDiceNum = totalDiceNumber;
            // 주사위 게임 시작
            while (currentDiceNum > 0)
            {
                int diceValue = RollADice(); // 주사위 굴리기
                currentDiceNum--; // 주사위 굴렸으니까 남은 주사위갯수 차감
                currentTileIndex += diceValue; // 플레이어 주사위 눈금만큼 전진

                Console.WriteLine($"현재 플레이어 위치: {currentTileIndex}");

                // 플레이어가 샛별칸을 몇개 지났는지 체크
                int passedStarTileNum = currentTileIndex / 5 - previousTileIndex / 5;
                if (passedStarTileNum > 0)
                {
                    for (int i = 0; i < passedStarTileNum; i++)
                    {
                        int starTileindex = (currentTileIndex / 5 - i )* 5;

                        if (starTileindex > totalTile)
                            starTileindex -= totalTile;

                        TileInfo_Star tileInfo_Star = map.mapInfo.GetValueOrDefault(starTileindex) as TileInfo_Star;
                        if (tileInfo_Star != null)
                        {
                            currentStarPoint += tileInfo_Star.starValue;
                        }
                    }
                }
                // 현재칸이 최대칸을 넘어가버렸을때
                if (currentTileIndex > totalTile)
                {
                    currentTileIndex -= totalTile;
                }

                // 현재 칸의 정보 받아옴
                TileInfo info = map.mapInfo.GetValueOrDefault(currentTileIndex);
                if (info == null)
                {
                    Console.WriteLine($"Failed to get tileinfo. num : {currentTileIndex}");
                    return;
                }
                info.TileEvent(); // 칸의 이벤트호출

                previousTileIndex = currentTileIndex;
                Console.WriteLine($"현재 샛별 점수 : {currentStarPoint}");
                Console.WriteLine($"남은 주사위 갯수 : {currentDiceNum}");
            }
            Console.WriteLine($"Game Finished ! You got total {currentStarPoint} stars");
        }
        static int RollADice()
        {
            string userInput = "Default";
            while (userInput != "")
            {
                Console.WriteLine("Roll A Dice ! Press Enter");
                userInput = Console.ReadLine();
            }
            random = new Random();
            int diceValue = random.Next(1, 7);
            Console.WriteLine($"DiceValue : {diceValue}");
            DisplayDice(diceValue);
            return diceValue;
        }

        static void DisplayDice(int diceValue)
        {
            switch (diceValue)
            {
                case 1:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("└───────────┘");
                    break;
                case 2:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●        │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│         ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 3:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●        │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│         ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 4:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 5:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 6:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                default:
                    break;
            }
        }

    }
}
