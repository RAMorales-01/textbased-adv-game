using System;
using System.Threading;
using TextDelay;

namespace GameStructure
{
    internal static class Title
    {
        internal static void ShowTitleScreen()
        { 
            LoadingSimulation();
            DisplayGameTitle();
            ViewInstructions();
        }
        private static void LoadingSimulation()
        {
            Console.Write("Loading game");
            Thread.Sleep((int)Delay.Medium);
            Console.Write(".");
            Thread.Sleep((int)Delay.Medium); 
            Console.Write(".");
            Thread.Sleep((int)Delay.Medium); 
            Console.Write(".");
            Console.Clear();
        }

        /// <summary>
        /// Game title made in ASCII, with this very cool webpage: https://ascii.today
        /// </summary>
        private static void DisplayGameTitle()
        {
            Console.WriteLine(@"  
                         _____ _            __  __           _                    
                        |_   _| |__   ___  |  \/  | __ _ ___| |_ ___ _ __         
                          | | | '_ \ / _ \ | |\/| |/ _` / __| __/ _ \ '__|        
                          | | | | | |  __/ | |  | | (_| \__ \ ||  __/ |           
                          |_| |_|_|_|\___| |_|  |_|\__,_|___/\__\___|_|           
                                 ___  / _|                                               
                                / _ \| |_                                                
                               | (_) |  _|                                               
                         ____   \___/|_|               _____                      
                        |  _ \  ___   ___  _ __ ___   |_   _|____      _____ _ __ 
                        | | | |/ _ \ / _ \| '_ ` _ \    | |/ _ \ \ /\ / / _ \ '__|
                        | |_| | (_) | (_) | | | | | |   | | (_) \ V  V /  __/ |   
                        |____/ \___/ \___/|_| |_| |_|   |_|\___/ \_/\_/ \___|_|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t-Game by RAMorales-01");
            Console.WriteLine("\n"); 
            Thread.Sleep((int)Delay.Medium);
            Console.WriteLine("\t\t\t\t\tPress KEY to start");
            Console.ReadKey();
        }

        /// <summary>
        /// Player can choose to view the game instructions or proceed directly to the game.
        /// </summary>
        private static void ViewInstructions()
        {
            do
            {
                Console.Clear();
                Console.Write("View Instructions? Y/N: ");
                var readInput = Console.ReadLine()?.ToUpper().Trim();
                if(readInput == null)
                {
                    Console.WriteLine("\nERROR: An unexpected error occurred while reading input. Please try again.");
                    Thread.Sleep((int)Delay.Long);
                    continue;
                }

                if(string.IsNullOrEmpty(readInput))
                {
                    Console.WriteLine("\nInput cannot be empty or void. Please try again.");
                    Thread.Sleep((int)Delay.Long);
                    continue;
                }
                else if(readInput == "Y" || readInput == "YES")
                {
                    DisplayGameInstructions();
                    break;
                }
                else if(readInput == "N" || readInput == "NO")
                {
                    break;
                } 
                else
                {
                    Console.WriteLine("\nNOTE: Input not valid. Please try again.");
                    Thread.Sleep((int)Delay.Long);
                    continue;
                }
            }while(true);
        }

        /// <summary>
        /// Displays the basic game instructions to the player
        /// </summary>
        private static void DisplayGameInstructions()
        {
            Console.Clear();
            Thread.Sleep((int)Delay.Short);
            Console.WriteLine("About:");
            Thread.Sleep((int)Delay.Long);
            Console.WriteLine("\nThe game consist of a simple turn base combat, the player starts");
            Console.WriteLine("with low level equipment and a small amount of gold to buy new equipment or healing potions.");
            Thread.Sleep((int)Delay.Long);
            Console.WriteLine("\nThe player must traverse each floor of the tower and survive the battle with a monster generated at random.");
            Console.WriteLine("After winning the battle the player will get a choice to move to the next random encounter for a maximum of 5 encounters in total,");
            Console.WriteLine("or quit and go back to the main hall of the tower where the player can get access to the shop of the game, in this store the player can");
            Console.WriteLine("buy new equipment according to its current warrior rank or heal its HP.");
            Thread.Sleep((int)Delay.Long);
            Console.WriteLine("\nThe player cannot heal during the combat rounds, and the only by buying the healing potions at the shop.");
            Thread.Sleep((int)Delay.Long);
            Console.WriteLine("\nAfter clearing 2 floors the player will get the chance to defeat a boss, if the player dies before defeating the boss,");
            Console.WriteLine("it will lose half of his/her collected gold and all the equipment goes back to the starting equipmen.");
            Console.WriteLine("If the player beats the boss then will unlock a checkpoint and proceed to the next floors of the tower.");
            Thread.Sleep((int)Delay.Long);
            Console.WriteLine("\npress KEY to exit and continue to the main game.");
            Console.ReadKey();
        }
    }
}
