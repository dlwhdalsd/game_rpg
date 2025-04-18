using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_rpg
{
    static class Shop
    {
        static List<ShopItem> shopItems = new List<ShopItem>();

        static Shop()
        {
            
            shopItems.Add(new ShopItem("무쇠갑옷", "방어력 +5", "튼튼한 갑옷", ItemType.Armor, 500));
            shopItems.Add(new ShopItem("스파르타의 창", "공격력 +7", "전설의 창", ItemType.Weapon, 700));
            shopItems.Add(new ShopItem("낡은 검", "공격력 +2", "평범한 검", ItemType.Weapon, 200));

            shopItems.Add(new ShopItem("청동 갑옷", "방어력 +9", "튼튼한 청동으로 만들어진 갑옷입니다.", ItemType.Armor, 900));
            shopItems.Add(new ShopItem("강철 검", "공격력 +12", "예리한 강철로 만든 강한 검입니다.", ItemType.Weapon, 1200));
            shopItems.Add(new ShopItem("모험가의 망토", "방어력 +3", "가벼운 방어구로 이동이 편리합니다.", ItemType.Armor, 300));

            shopItems.Add(new ShopItem("흘러내리는 언어", "공격력 +30", "오염의 한계는 어디까지일까요?", ItemType.Weapon, 3000));
            shopItems.Add(new ShopItem("넥타르", "공격력 +30", "신께서 이르시되 나의 피는 포도주요...", ItemType.Weapon, 3000));

        }
        
        public static void Open(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====  상점에 오신 것을 환영합니다! =====\n");

                for (int i = 0; i < shopItems.Count; i++)
                {
                    shopItems[i].Display(i + 1);
                }

                Console.WriteLine("\n0. 나가기");
                Console.WriteLine($"\n소지 골드: {player.Gold} G");
                Console.Write("\n구매할 아이템 번호를 입력해주세요: ");
                string input = Console.ReadLine();

                if (input == "0") return;

                if (int.TryParse(input, out int index) && index >= 1 && index <= shopItems.Count)
                {
                    TryPurchase(shopItems[index - 1], player);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }
            }
        }

        static void TryPurchase(ShopItem item, Player player)
        {
            Console.WriteLine($"\n{item.Name}을(를) {item.Price}G에 구매하시겠습니까? (y/n)");
            Console.Write(">> ");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                if (player.Gold >= item.Price)
                {
                    player.Gold -= item.Price;

                    // 새 Item 객체로 인벤토리에 추가 (ShopItem이 아닌)
                    Inventory.Add(new Item(item.Name, item.StatText, item.Description, item.Type));
                    Console.WriteLine($"{item.Name}을(를) 구매했습니다!");
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                }
            }
            else
            {
                Console.WriteLine("구매를 취소했습니다.");
            }

            Console.WriteLine("\n아무 키나 누르면 계속합니다...");
            Console.ReadKey();
        }
    }
}
