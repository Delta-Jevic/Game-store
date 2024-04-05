/**********************************************************************
*** NAME	    : Jevic Tshilumba                                   ***
*** CLASS	    : Object Oriented Programming                       ***
*** ASSIGNMENT	:  4                                               ***
*** DUE DATE	: 04-05-24                                          ***
*** INSTRUCTOR	: Ken GAMRADT                                           ***
*********************************************************************************************
*** DESCRIPTION : ) using C# classes named Game, Platform, PS5, Switch and interface IPlatform and an appropriate set of C# files as discussed in class ***
************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;

namespace StoreNS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Available games for PS5
            List<Game> ps5Games = new List<Game>
            {
                new Game("Call of Duty", 54, 3),
                new Game("Elden Ring", 50, 4),
                new Game("Horizon", 46, 5),
                new Game("Uncharted", 57, 2)
            };

            // Available games for Switch
            List<Game> switchGames = new List<Game>
            {
                new Game("Animal Crossing", 46, 3),
                new Game("Link's Awakening", 50, 5),
                new Game("Pokemon Legends", 57, 1)
            };

            // Creating instances of platforms
            Platform ps5 = new PS5(ps5Games, 0, 0, 4, 4);
            Platform switchPlatform = new Switch(switchGames, 0, 0, 3, 3);

            // Displaying the menu
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to the Console Game System Store");
                Console.WriteLine("Choose a console game system:");
                Console.WriteLine("1. PS5");
                Console.WriteLine("2. Switch");
                Console.WriteLine("3. Exit");

                // Input from the user
                string input = Console.ReadLine() ?? ""; 



                switch (input)
                {
                    case "1":
                        Console.WriteLine("Buying games for PS5:");
                        ps5.Start();
                        break;
                    case "2":
                        Console.WriteLine("Buying games for Switch:");
                        switchPlatform.Start();
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Thank you for using the Console Game System Store.");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
