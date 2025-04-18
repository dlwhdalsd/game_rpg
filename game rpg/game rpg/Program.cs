using System;

namespace game_rpg
{
    internal class Program
    {
        static Player player;

        static void Main(string[] args)
        {
            CreatePlayer(); 
            ShowIntro();

            while (true)
            {
                ShowMainMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        player.ShowStatus();
                        WaitForBack(); 
                        break;
                    case "2":
                        Inventory.Show(player);
                        break;
                    case "3":
                        Shop.Open(player);   
                        break;
                        
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }

                Console.WriteLine("\n아무 키나 누르면 계속합니다...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowIntro()
        {
            
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
        }

        static void CreatePlayer()
        {
            player = new Player("Chad", "전사", 1, 10, 5, 100, 5000);
            /*
            Name 
            Job 
            Level 
            BaseAttack 
            BaseDefense 
            HP 
            Gold 
             */
            player.EquippedItems.Clear();

        }

        static void WaitForBack()
        {
            while (true)
            {
                Console.Write(">> ");
                string back = Console.ReadLine();
                if (back == "0") break;
                Console.WriteLine("잘못된 입력입니다. 0을 입력해 돌아가세요.");
            }
        }
    }
}