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
using System.Linq;

namespace StoreNS
{
    public abstract class Platform:IPlatform
    {
        internal List<Game> games {get; set;}
        protected int selected {get; set;}
        protected int paid {get; set;}
        internal int numberOfGames{get; set;}

        public int pay = 0;

        public Platform()  // Constructor
        {
            numberOfGames = 0;
            this.games = new List<Game>();
        }

        public Platform (int NumberofGames, int Payement, int Selected, List<Game> Games)
        {
            this.numberOfGames = NumberofGames;
            paid = Payement;
            selected = Selected;
            this.games = Games;
        }

        public virtual void Start()
        {
            Introduction();
            Selection();
            if(selected > 0)
            {
                Payement(ref pay);
                //if (paid >= games[selected - 1].Price)
                //{
                    Change();
                    Deliver();
                //}
            }
       }

        public abstract void Introduction();

       
        protected virtual void Selection()
        {
            Console.WriteLine("Available Games:");
            Console.WriteLine("----------------");
            int index = 1;
            numberOfGames = games.Count;
            Console.WriteLine("Game    price   Quantity.");
            for(int i=0; i < numberOfGames; i++)
            {
                if (games[i].Units >= 0)
                {
                    Console.WriteLine(index + ". "+ games[i].Name + "\t$"+games[i].Price+ "\t"+games[i].Units);
                    index ++;
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Select a game  ");
            bool valid = false;
            while(!valid)
            {
                Console.WriteLine("Select a number or Enter 0 to declien your order .");
                int choice = 0;
               
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine(choice);
                    Console.WriteLine(numberOfGames);
                }
                else
                {
                    Console.WriteLine("Error");
                }
               
                // Check if the customer entered a valid selection
                if (choice > 0 && choice <= numberOfGames)
                {
                    selected = choice;
                    // check if the game selected is out of stock
                    if (games.ElementAt(selected-1).Units == 0)
                    {
                        Console.WriteLine("Select another game.");
                        continue;
                    }
                    
                    
                    Console.WriteLine($"You have selected {games.ElementAt(selected - 1).Name}, Your cost is: ${games.ElementAt(selected - 1).Price}. You have {games.ElementAt(selected - 1).Units} units ");
                    Console.WriteLine("\n");
                    valid = true;
                    
                }
                else if(choice == 0) 
                {
                    Console.WriteLine(" Order decliened ");
                    selected = choice;
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Try again.");
                }
            }
        }
 


       protected virtual void Change()
        {
            Console.WriteLine("Change breakdown:");

            int remainingChange = pay - games.ElementAt(selected-1).Price;
            Console.WriteLine(pay);
            Console.WriteLine(games.ElementAt(selected).Price);
            Dictionary<int, string> denominations = new Dictionary<int, string>
            {
                { 10, "10-dollar bills" },
                { 1, "1-dollar bills" }
            };
            Console.WriteLine("Before Loop");
            foreach (KeyValuePair<int, string> denomination in denominations)
            {
                int numberOfBills = remainingChange / denomination.Key;
                remainingChange %= denomination.Key;
                Console.WriteLine(numberOfBills);
                if (numberOfBills > 0)
                {
                    Console.WriteLine($"Number of {denomination.Value} to be returned: {numberOfBills}");
                }
            }
        }


        protected virtual void Payement( ref int Total)
        {
            Console.WriteLine("The game only takes bills of $10, $20");
           Console.WriteLine("Enter your payment amounts for $10 and $20 bills:");

           int FirstEntered = 0;
           int SecondEntered = 0;

           string input;
           input = Console.ReadLine()?? ""; 

           if (input != null)
           {
             FirstEntered = int.Parse(input);
           }

           input = Console.ReadLine()?? ""; 

           if (input != null)
           {
               SecondEntered = int.Parse(input);
           }

           int total = FirstEntered * 10 + SecondEntered * 20 ;

           Console.WriteLine($"The Total payment of your is: ${total}");

           if (total< paid )
            {
               Console.WriteLine("Insufficient funds. You need $"+ (paid - total)+"more in order to purchase your game");
            }
           else
           {
               paid= total;
           }
        }
        protected virtual void Deliver()
        {
           
            Console.WriteLine("Thank you, Your game is delivered");
                   
        }


    }
}


