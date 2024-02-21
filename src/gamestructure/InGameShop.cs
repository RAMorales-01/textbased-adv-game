using System;
using System.Threading;
using GameCharacters;
using GameEquipment;
using Ranks;
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
                    Shopping.ShopCategoryHandler(player, selectedCategory); 
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
        internal static void ShopCategoryHandler(Player player, ItemCategory selected)
        {
            switch(selected)
            {
                case ItemCategory.Sword:
                    BuyEquipmentProcess(player, ItemCategory.Sword);
                    break;
                
                case ItemCategory.Shield:
                    BuyEquipmentProcess(player, ItemCategory.Shield);
                    break;

                case ItemCategory.Armor:
                    BuyEquipmentProcess(player, ItemCategory.Armor);
                    break;
                
                case ItemCategory.Healing:
                    // Here goes the method to buy healing.
                    break;
                
                case ItemCategory.Exit:
                    break;
            }
        }
        private static void BuyEquipmentProcess(Player player, ItemCategory selectedEquipment)
        {
            Console.Clear();

            Rank currentRank = player.WarriorRank;
            bool sameID;
            // Next var is hasn't been implemented yet. 
            bool result;

            switch(selectedEquipment)
            {
                case ItemCategory.Sword:
                    Sword availableSword = new Sword(currentRank);
                    sameID = ShopItem.CheckItemID(player.EquipedSword!.ID, availableSword.ID, availableSword.Name);
                    if(!sameID)
                    {
                        ShopItem.DisplayItemInformation(player, availableSword);
                        Console.ReadKey(); // Remove after test. 
                    }
                    break;
                
                case ItemCategory.Shield:
                    Shield availableShield = new Shield(currentRank);
                    sameID = ShopItem.CheckItemID(player.EquipedShield!.ID, availableShield.ID, availableShield.Name);
                    break;
                
                case ItemCategory.Armor:
                    Armor availableArmor = new Armor(currentRank);
                    sameID = ShopItem.CheckItemID(player.EquipedArmor!.ID, availableArmor.ID, availableArmor.Name);
                    break;
            }
        }
    }
    internal class ShopItem
    {
        internal static void DisplayItemInformation(Player player, object selectedEquipment)
        {
            switch(selectedEquipment)
            {
                case Sword currentRankSword:
                    SwordInfo(player, (Sword)selectedEquipment);
                    break;
                
                case Shield currentRankShield:
                    ShieldInfo(player, (Shield)selectedEquipment);
                    break;

                case Armor currentRankArmor:
                    ArmorInfo(player, (Armor)selectedEquipment);
                    break;
            }
        }
        internal static bool CheckItemID(string equipedID, string shopItemID, string shopItemName)
        {
            if(equipedID == shopItemID)
            {
                Console.WriteLine($"\nYou already bought and equiped the {shopItemName}\n");
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void SwordInfo(Player player, Sword sword)
        {
            Console.WriteLine($"With your current '{player.WarriorRank}' Rank you are able to buy this weapon:\n");
            Console.WriteLine($"\t\t\t{sword.Name}\n");
            Console.WriteLine($"\"{sword.Info}\"");
            Console.WriteLine($"\nDamage: {sword.SwordDmg}");
            Console.WriteLine($"Weight: {sword.Weight} kgs");
            Console.WriteLine($"Price: {sword.Price} gold");
            Console.WriteLine($"\nWARNING: you will lose the {player.EquipedSword?.Name}");
        }
        private static void ShieldInfo(Player player, Shield shield)
        {
            Console.WriteLine($"With your current '{player.WarriorRank}' Rank you are able to buy this weapon:\n");
            Console.WriteLine($"\t\t\t{shield.Name}\n");
            Console.WriteLine($"\"{shield.Info}\"");
            Console.WriteLine($"\nDamage: {shield.ShieldDef}");
            Console.WriteLine($"Weight: {shield.Weight} kgs");
            Console.WriteLine($"Price: {shield.Price} gold");
            Console.WriteLine($"\nWARNING: you will lose the {player.EquipedShield?.Name}");
        }
        private static void ArmorInfo(Player player, Armor armor)
        {
            Console.WriteLine($"With your current '{player.WarriorRank}' Rank you are able to buy this weapon:\n");
            Console.WriteLine($"\t\t\t{armor.Name}\n");
            Console.WriteLine($"\"{armor.Info}\"");
            Console.WriteLine($"\nDamage: {armor.ArmorDef}");
            Console.WriteLine($"Weight: {armor.Weight} kgs");
            Console.WriteLine($"Price: {armor.Price} gold");
            Console.WriteLine($"\nWARNING: you will lose the {player.EquipedArmor?.Name}");
        }
    }
}