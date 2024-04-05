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
    public class Switch :Platform
   {
       private int NumberofDifGames {get; set;}

       public Switch() :base() // constructor

       {
            NumberofDifGames = 0;
       }

       public Switch(List<Game>games, int selected, int paid, int numberOfGames, int NumberofDifGames) 
       : base(numberOfGames, paid, selected, games)

       {
          NumberofDifGames = numberOfGames;
       }
       
       private Switch(Switch other) // copy constructor
       {
        this.NumberofDifGames = other.NumberofDifGames;
       }

       public override void Introduction()
       {
           Console.WriteLine("Welcome to the Switch Game");
       }

       protected override void Change()
        {
            Console.WriteLine("Change breakdown: $5 bills, $2 bills, and $1 bills");

            int remainingChange = paid - games.ElementAt(selected).Price;
            int[] denominations = { 5, 2, 1 };

            foreach (int bill in denominations)
            {
                int numberOfBills = remainingChange / bill;
                remainingChange %= bill;

                if (numberOfBills > 0)
                {
                    Console.WriteLine($"You'll receive {numberOfBills} ${bill} bills as change.");
                }
            }
        }

   }
}