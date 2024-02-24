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
                    BuyEquipment(player, ItemCategory.Sword);
                    break;
                
                case ItemCategory.Shield:
                    BuyEquipment(player, ItemCategory.Shield);
                    break;

                case ItemCategory.Armor:
                    BuyEquipment(player, ItemCategory.Armor);
                    break;
                
                case ItemCategory.Healing:
                    // Here goes the method to buy healing.
                    break;
                
                case ItemCategory.Exit:
                    break;
            }
        }
        private static void BuyEquipment(Player player, ItemCategory selectedEquipment)
        {
            Console.Clear();
    
            bool sameID;
            bool buyChoice;

            switch(selectedEquipment)
            {
                case ItemCategory.Sword:
                    Sword currentRankSword = new Sword(player.WarriorRank);
                    sameID = ShopItems.CheckEquipmentID(player.EquipedSword!.ID, currentRankSword.ID, currentRankSword.Name);
                    if(!sameID)
                    {
                        buyChoice = ConfirmBuy(player, currentRankSword, currentRankSword.Price);
                        if(buyChoice == true)
                        {
                            // here goes the code to equip the sword and subtract the cost from the player funds.
                        }
                    }
                    break;
                
                case ItemCategory.Shield:
                    Shield currentRankShield = new Shield(player.WarriorRank);
                    sameID = ShopItems.CheckEquipmentID(player.EquipedShield!.ID, currentRankShield.ID, currentRankShield.Name);
                    if(!sameID)
                    {
                        buyChoice = ConfirmBuy(player, currentRankShield, currentRankShield.Price);
                        if(buyChoice == true)
                        {
                            // here goes the code to equip the shield and subtract the cost from the player funds.
                        }
                    }
                    break;
                
                case ItemCategory.Armor:
                    Armor currentRankArmor = new Armor(player.WarriorRank);
                    sameID = ShopItems.CheckEquipmentID(player.EquipedArmor!.ID, currentRankArmor.ID, currentRankArmor.Name);
                    if(!sameID)
                    {
                        buyChoice = ConfirmBuy(player, currentRankArmor, currentRankArmor.Price);
                        if(buyChoice == true)
                        {
                            // here goes the code to equip the armor and subtract the cost from the player funds.
                        }
                    }
                    break;
            }
        }
        private static bool ConfirmBuy(Player player, object selectedEquipment, int selectedEquipmentCost)
        {
            string? readInput = string.Empty;

            do
            {
                Console.Clear();

                ShopItems.DisplayItemInformation(player, selectedEquipment);

                Console.WriteLine($"\nDo you wish to buy it?\t\tYou have: {player.PlayerFunds} gold");
                Console.Write("Y/N: ");
                readInput = Console.ReadLine()?.ToUpper().Trim();
                if(readInput == null)
                {
                    Console.WriteLine("\nERROR: An unexpected error occurred while reading input. Please try again.");
                    Thread.Sleep((int)Delay.Medium);
                    continue;
                }

                if(string.IsNullOrEmpty(readInput))
                {
                    Console.WriteLine("\nNOTE: Input cannot be void or empty, please try again\n");
                    Thread.Sleep((int)Delay.Medium);
                    continue;
                }
                else if((readInput == "Y" || readInput == "YES") || (readInput == "N" || readInput == "NO"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nNOTE: Input not valid, must be Y or N only, please try again\n");
                    Thread.Sleep((int)Delay.Medium);
                    continue;
                }
            }while(true);

            if((readInput == "Y" || readInput == "YES") && player.PlayerFunds >= selectedEquipmentCost)
            {
                return true;
            }
            else if((readInput == "Y" || readInput == "YES") && player.PlayerFunds < selectedEquipmentCost)
            {
                Console.WriteLine("\nSorry you don't have enough gold\n");
                return false;
            }
            else
            {
                return false;
            }
        }
    }
    internal class ShopItems
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
        internal static bool CheckEquipmentID(string equipedID, string shopItemID, string shopItemName)
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
            Console.WriteLine($"\nDefense: {shield.ShieldDef}");
            Console.WriteLine($"Weight: {shield.Weight} kgs");
            Console.WriteLine($"Price: {shield.Price} gold");
            Console.WriteLine($"\nWARNING: you will lose the {player.EquipedShield?.Name}");
        }
        private static void ArmorInfo(Player player, Armor armor)
        {
            Console.WriteLine($"With your current '{player.WarriorRank}' Rank you are able to buy this weapon:\n");
            Console.WriteLine($"\t\t\t{armor.Name}\n");
            Console.WriteLine($"\"{armor.Info}\"");
            Console.WriteLine($"\nDefense: {armor.ArmorDef}");
            Console.WriteLine($"Weight: {armor.Weight} kgs");
            Console.WriteLine($"Price: {armor.Price} gold");
            Console.WriteLine($"\nWARNING: you will lose the {player.EquipedArmor?.Name}");
        }
        private static void HealingPotionsInfo()
        {
            // Here goes the code to display potion healing description.
        }
    }
}