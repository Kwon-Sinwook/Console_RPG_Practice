using System;
using System.ComponentModel.Design;

namespace Console_RPG
{
    class Program
    {
        public class Shop_Item // 상점의 아이템과 정보를 담은 클래스
        {
            public List<List<string>> itemList = new List<List<string>>() // 2차원 리스트로 아이템 정보를 저장하는 코드, 맨 마지막은 장착 여부를 의미한다.
            {
               new List<string>() {"수련자 갑옷",     "방어력", "5",  "수련에 도움을 주는 갑옷입니다.",                    "1000", "X"},
               new List<string>() {"무쇠갑옷",        "방어력", "9",  "무쇠로 만들어져 튼튼한 갑옷입니다",                 "150",  "X"},
               new List<string>() {"스파르타의 갑옷", "방어력", "15", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", "3500", "X"},
               new List<string>() {"낡은 검",         "공격력", "2",  "쉽게 볼 수 있는 낡은 검 입니다.",                   "600",  "X"},
               new List<string>() {"청동 도끼",       "공격력", "5",  "어디선가 사용됐던거 같은 도끼입니다.",              "1500", "X"},
               new List<string>() {"스파르타의 창",   "공격력", "7",  "스파르타의 전사들이 사용했다는 전설의 창입니다.",   "300",  "X"}
            };

        }

        public class Player
        {
            public int level = 1;
            public string name = "르탄";
            public int offense = 10;
            public int defense = 5;
            public int health = 100;
            int gold = 1500;              // 기본 정보를 가지는 변수들이다.

            public int add_offense = 0;   // 장비로 인한 추가 공격력 저장 변수
            public int add_defense = 0;   // 장비로 인한 추가 방어력 저장 변수

            public List<List<string>> haveItem = new List<List<string>>(); // 현재 플레이어가 가진 아이템 저장 리스트이다.
            public Shop_Item shop_item = new Shop_Item(); // 상점 아이템을 가져오기 위한 코드
            public void View_rtan() // 상태를 보기 위한 메소드
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("상태 보기");
                    Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                    Console.WriteLine("Lv. {0}", level);
                    Console.WriteLine("{0} ( 전사 )", name);

                    if (add_offense != 0)     //추가 공격력이 존재한다면 추가 공격력도 출력
                        Console.WriteLine("공격력 : {0} (+{1})", offense, add_offense);

                    else Console.WriteLine("공격력 : {0}", offense);

                    if (add_defense != 0)     //추가 방어력이 존재한다면 추가 방어력도 출력
                        Console.WriteLine("방어력 : {0} (+{1})", defense, add_defense);

                    else Console.WriteLine("방어력 : {0}", defense);

                    Console.WriteLine("체력 " + health);
                    Console.WriteLine("Gold " + gold + " G\n");

                    Console.Write("0. 나가기\n>> ");
                    int input = int.Parse(Console.ReadLine());

                    if (input == 0)
                        break;
                }

            }

            public void View_Inventory()   // 인벤토리 확인 아이템
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                    Console.WriteLine("[아이템 목록]");


                    foreach (var a in haveItem) // 현재 내가 가진 아이템 정보 확인
                    {
                        Console.WriteLine("- {0} | {1} +{2} | {3}", a[0], a[1], a[2], a[3]);
                    }

                    Console.WriteLine("\n1. 장착 관리");
                    Console.WriteLine("0. 나가기\n");

                    Console.Write("원하시는 행동을 입력해주세요\n>> ");
                    int input = int.Parse(Console.ReadLine());

                    if (input == 1)
                        Equipment_Management(); // 장착 관리 메소드로 이동

                    else if (input == 0)
                        break;

                    else continue;
                }
            }


            public void Equipment_Management()
            {
                while (true)
                {
                    int number = 1;
                    Console.Clear();
                    Console.WriteLine("인벤토리 - 장착 관리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                    Console.WriteLine("[아이템 목록]");
                    foreach (var a in haveItem)
                    {
                        Console.WriteLine("- {0} {1} | {2} +{3} | {4}", number++, a[0], a[1], a[2], a[3]);
                    }

                    Console.WriteLine("\n0. 나가기\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");

                    int input = int.Parse(Console.ReadLine());

                    if (0 < input && input < number) // 사용자가 [장착/해제]를 할 아이템 번호를 누르면 작동
                    {
                        if (haveItem[input - 1][5] == "X") // 만일 장착하지 않았다면
                        {
                            haveItem[input - 1][5] = "Y";                               //장착 여부를 Y로 바꾸고
                            haveItem[input - 1][0] = "[E]" + haveItem[input - 1][0];    //장비 이름 앞에 [E] 추가

                            switch (haveItem[input - 1][1]) // 아이템 정보의 2번째 값이 공격력인지 방어력인지 확인하는 switch문
                            {
                                case "공격력":
                                    {
                                        int value = int.Parse(haveItem[input - 1][2]); // 아이템 정보에서 추가 능력치를 가져오는 코드
                                        offense += value;
                                        add_offense += value; // 기존 공격력에 더한 뒤, 추가 공격력에도 저장한다.
                                        break;
                                    }

                                case "방어력":
                                    {
                                        int value = int.Parse(haveItem[input - 1][2]);
                                        defense += value;
                                        add_defense += value; // 기존 방어력에 더한 뒤, 추가 방어력에도 저장한다.
                                        break;
                                    }
                            }
                        }

                        else
                        {
                            haveItem[input - 1][5] = "X";                                       //이미 장착이 된 상태라면, 장착 여부를 X로 바꾼다.
                            haveItem[input - 1][0] = haveItem[input - 1][0].Replace("[E]", ""); //이름에 붙은 [E]를 제거한다

                            switch (haveItem[input - 1][1])
                            {
                                case "공격력":
                                    {
                                        int value = int.Parse(haveItem[input - 1][2]);
                                        offense -= value;
                                        add_offense -= value;
                                        break;
                                    }

                                case "방어력":
                                    {
                                        int value = int.Parse(haveItem[input - 1][2]);
                                        defense -= value;
                                        add_defense -= value;
                                        break;
                                    }
                            }
                        }
                    }

                    else if (input == 0)
                        break;

                    else continue;

                }
            }


            public void Go_shop() // 상점으로 이동하는 메소드
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("상점");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                    Console.WriteLine("[보유골드]");
                    Console.WriteLine("{0} G\n", gold);

                    Console.WriteLine("[아이템 목록]");

                    foreach (var a in shop_item.itemList) // 상점의 아이템 목록을 가져온다.
                    {
                        Console.WriteLine("- {0} | {1} +{2} | {3} | {4}", a[0], a[1], a[2], a[3], a[4]);
                    }

                    Console.WriteLine("\n1. 아이템 구매");
                    Console.WriteLine("0. 나가기\n");

                    Console.WriteLine("원하시는 행동을 입력해주세요");
                    Console.Write(">> ");

                    int input = int.Parse(Console.ReadLine());

                    if (input == 1)
                        Buy_item(); // 아이템 구매 메소드 출력

                    else if (input == 0)
                        break;

                    else continue;
                }
            }

            public void Buy_item()
            {
                while (true)
                {
                    int number = 1;
                    Console.Clear();
                    Console.WriteLine("상점 아이템 구매");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                    Console.WriteLine("[보유골드]");
                    Console.WriteLine("{0} G\n", gold);

                    Console.WriteLine("[아이템 목록]");
                    foreach (var a in shop_item.itemList)
                    {
                        Console.WriteLine("- {0} {1} | {2} +{3} | {4} | {5}", number++, a[0], a[1], a[2], a[3], a[4]);
                    }

                    Console.WriteLine("\n0. 나가기\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");

                    int input = int.Parse(Console.ReadLine());

                    if (0 < input && input < number) // 사용자가 아이템을 선택했을 시 진입
                    {
                        if (shop_item.itemList[input - 1][4] == "구매 완료") // 우선 선택한 아이템이 이미 구매했던 아이템인지 확인
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                            Thread.Sleep(1000);
                            continue;
                        }

                        int price = int.Parse(shop_item.itemList[input - 1][4]); // 구매했던 아이템이 아니면, 아이템의 가격 값 저장

                        if (haveItem.Count == 0) // 내가 가진 아이템이 하나도 없었다면
                        {

                            if (gold > price)
                            {
                                gold -= price;   //소지금에서 가격 빼기
                                shop_item.itemList[input - 1][4] = "구매 완료"; // 구매한 아이템의 가격 정보를 구매 완료로 바꾸기
                                haveItem.Add(shop_item.itemList[input - 1]); // 내가 가진 아이템 리스트에 추가.
                                Console.WriteLine("구매를 완료했습니다.");
                            }

                            else Console.WriteLine("Gold가 부족합니다");

                            Thread.Sleep(1000);
                        }

                        else
                        {
                            if (gold < price)
                                Console.WriteLine("Gold가 부족합니다");

                            else
                            {
                                gold -= price;
                                shop_item.itemList[input - 1][4] = "구매 완료";
                                haveItem.Add(shop_item.itemList[input - 1]);
                                Console.WriteLine("구매를 완료했습니다.");
                            }

                            Thread.Sleep(1000);
                        }
                    }

                    else if (input == 0)
                        break;

                    continue;
                }
            }
        }


        static void Main(string[] args)
        {
            Player rtan = new Player(); // Player형 변수 rtan을 선언한다.

            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점\n");

                Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        rtan.View_rtan(); // 상태 보기로 이동
                        break;

                    case 2:
                        rtan.View_Inventory(); // 인벤토리로 이동
                        break;

                    case 3:
                        rtan.Go_shop(); // 상점으로 이동
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}
