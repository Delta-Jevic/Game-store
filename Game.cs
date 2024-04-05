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
    // Declaration of a class named Game
    public class Game
    {
      
        public string Name { get; set; }   // Name of the game
        public int Price { get; set; }      // Price of the game
        public int Units { get; set; }      // Number of units of the game available in the store

        public bool InStock => Units > 0; 
        
        public Game() // Default constructor
        {
            Name = "";      
            Price = 0;      
            Units = 0;      
        }

        
        public Game(string name, int price, int units) // Parameterized constructor
        {
            
            Name = name;    // Assign provided name
            Price = price;  // Assign provided price
            Units = units;  // Assign provided units
        }

        
        public Game(Game other)   //  copy constructor
        {
            
            this.Name = other.Name;     // Copy name
            this.Price = other.Price;   // Copy price
            this.Units = other.Units;   // Copy units
        }
    }
}
