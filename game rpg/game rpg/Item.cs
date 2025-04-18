using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_rpg
{
    enum ItemType
    {
        Weapon,
        Armor
    }

    class Item
    {
        public string Name { get; }
        public string Description { get; }
        public string StatText { get; }
        public ItemType Type { get; }
        public bool IsEquipped { get; set; }

        public string StatType { get; }   // "공격력" or "방어력"
        public int StatValue { get; }     // 7, 5 등

        public Item(string name, string statText, string description, ItemType type, bool isEquipped = false)
        {
            Name = name;
            StatText = statText;
            Description = description;
            Type = type;
            IsEquipped = isEquipped;

            var parts = statText.Split(' ');
            StatType = parts[0];
            StatValue = int.Parse(parts[1].Replace("+", ""));
        }

        public void Display(int index = -1)
        {
            string equippedTag = IsEquipped ? "[E]" : "   ";
            string prefix = index >= 0 ? $"{index}. " : "- ";
            Console.WriteLine($"{prefix}{equippedTag}{Name.PadRight(15)} | {StatText} | {Description}");
        }
    }
}
