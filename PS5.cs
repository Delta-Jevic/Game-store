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


namespace StoreNS
{ 
    // Declaration of a class named PS5 which inherits from the Platform class
    public class PS5 : Platform
    {
        
        private int NumberofDifGames { get; set; } // Private property representing the number of different games

        
        public PS5() : base() // Default constructor
        {
            NumberofDifGames = 0;
        }

        // Parameterized constructor
        public PS5(List<Game> games, int selected, int paid, int numberOfGames, int NumberofDifGames) : base(numberOfGames, paid, selected, games)
        {
            // Initialize NumberofDifGames with the provided value
            NumberofDifGames = numberOfGames;
        }
       
        private PS5(PS5 other) // Private copy constructor
        {
            
            this.NumberofDifGames = other.NumberofDifGames;
        }

       
        public override void Introduction()
        {
            // Display a welcome message
            Console.WriteLine("Welcome to the Ps5 Game");
        }

        // Override method for Payement
        protected override void Payement(ref int Total)
        {
            // Display payment instructions
            Console.WriteLine("The game only takes bills of $10, $5, $1");
            Console.WriteLine("Enter your payment amounts for $10, $5, and $1 bills:");

            int numberOfTenDollar = 0;
            int numberOfFiveDollar = 0;
            int numberOfOneDollar = 0;

            // Read input for the number of $10 bills
            string input;
            input = Console.ReadLine()?? ""; 

            if (input != null)
            {
                numberOfTenDollar = int.Parse(input);
            }

            // Read input for the number of $5 bills
            input = Console.ReadLine()?? ""; 

            if (input != null)
            {
                numberOfFiveDollar = int.Parse(input);
            }

            // Read input for the number of $1 bills
            input = Console.ReadLine()?? ""; 

            if (input != null)
            {
                numberOfOneDollar = int.Parse(input);
            }

            // Calculate the total payment
            int total = numberOfTenDollar * 10 + numberOfFiveDollar * 5 + numberOfOneDollar * 1;

            // Display the total payment
            Console.WriteLine($"The Total payment of your is: ${total}");

            // Check if the total payment is less than required
            if (total < paid)
            {
                // Display an error message for insufficient funds
                Console.WriteLine("Insufficient funds. You need $" + (paid - total) + " more in order to purchase your game");
            }
            else
            {
                // Update the Total with the calculated total payment
                Total = total;
            }
        }
    }
}



