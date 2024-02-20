using System;
using System.Threading;
using GameCharacters;
using GameEquipment;
using TextTimeDelay;

namespace GameStructure
{
    public enum ItemCategory
    {
        Sword = 1,
        Shield = 2,
        Armor = 3,
        Healing = 4,
        Exit = 5
    }
    internal class Shop
    {
        internal static void EnterShop(Player player)
        {
            bool keepShopping = true;

            do
            {
                Console.Clear();
                
                DisplayAvailableEquipmentToPlayer(player);

                ItemCategory selectedCategory = DisplayShopCategories();

                if((int)selectedCategory < 1 || (int)selectedCategory > 5)
                {
                    Console.WriteLine("\nSorry that is not an option\n");
                }
                else if((int)selectedCategory >= 1 && (int)selectedCategory <= 4)
                {
                    // Here goes helper method to handle the player choosen category 
                }
                else if((int)selectedCategory == 5)
                {
                    break;
                }

                keepShopping = AskToContinueShopping();

            }while(keepShopping);
        }
        private static void DisplayAvailableEquipmentToPlayer(Player player)
        {
            Sword newAvailableSword = new Sword(player.WarriorRank);
            Shield newAvailableShield = new Shield(player.WarriorRank);
            Armor newAvailableArmor = new Armor(player.WarriorRank);

            Console.WriteLine("This is the currently available equipment I have for you right now:");
            if(newAvailableSword.ID != player.EquipedSword?.ID)
            {
                Console.Write($"*-{newAvailableSword.Name}\t");
            }
            if(newAvailableShield.ID != player.EquipedShield?.ID)
            {
                Console.Write($"*-{newAvailableShield.Name}\t\t");
            }
            if(newAvailableArmor.ID != player.EquipedArmor?.ID)
            {
                Console.Write($"*-{newAvailableArmor.Name}\n");
            }
            else
            {
                Console.Write("It seems you already bought every piece of equipment I have for now\n");
            }
            Thread.Sleep((int)Delay.Medium);
        } 
        private static ItemCategory DisplayShopCategories()
        {
            Console.WriteLine("\nWhat are you buying?\n");
            Thread.Sleep((int)Delay.Short);
            Console.WriteLine("1- Sword");
            Thread.Sleep((int)Delay.Short);
            Console.WriteLine("2- Shield");
            Thread.Sleep((int)Delay.Short);
            Console.WriteLine("3- Armor");
            Thread.Sleep((int)Delay.Short);
            Console.WriteLine("4- I need healing..");
            Thread.Sleep((int)Delay.Short);
            Console.WriteLine("5- Exit");
            Thread.Sleep((int)Delay.Short);
            Console.Write(": ");
            var readInput = Console.ReadLine();
                
            if(!int.TryParse(readInput, out int choice))
            {
                Console.WriteLine("\nNOTE: Input not valid, you must choose only the presented options\n");
            }
            
            return (ItemCategory)choice;
        }
        private static bool AskToContinueShopping()
        {
            Thread.Sleep((int)Delay.Medium);
            Console.Clear();

            do
            {
                Thread.Sleep((int)Delay.Short);
                Console.WriteLine("Anything else?");
                Console.Write("Y/N: ");
                var readInput = Console.ReadLine()?.ToUpper().Trim();
                if(readInput == null)
                {
                    Console.WriteLine("\nERROR: An unexpected error occurred while reading input. Please try again.");
                    Thread.Sleep((int)Delay.Medium);
                    continue;
                }

                if(string.IsNullOrEmpty(readInput))
                {
                    Console.WriteLine("\nNOTE: Input cannot be void or empty, press ENTER try again\n");
                    Thread.Sleep((int)Delay.Medium);
                    continue;
                }
                else
                {
                    if(readInput == "N" || readInput == "NO")
                    {
                        Console.WriteLine("\nComback any time hehe\n");
                        return false;
                    }
                    else if(readInput == "Y" || readInput == "YES")
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("\nNOTE: Input not valid, please choose only Y or N. Please try again.\n");
                        Thread.Sleep((int)Delay.Medium);
                        continue;
                    }
                }
            }while(true); 
        }
    }
    internal class Shopping
    {

    }
}