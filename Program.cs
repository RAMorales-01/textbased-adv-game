using System;
using GameCharacters;
using GameEquipment;
using GameStructure;

namespace TextBasedGame
{
    class Program
    {
        public static void Main()
        {
            //Title.ShowTitleScreen();
            Sword sword = new Sword(Ranks.Rank.Default);
            Shield shield = new Shield(Ranks.Rank.Default);
            Armor armor = new Armor(Ranks.Rank.Default);
            Player player = new Player("Test", sword, shield, armor);
            Shop.EnterShop(player);
            Console.ReadKey();
        }
    }
}