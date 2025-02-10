using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame.App.Interfaces;

namespace TextAdventureGame.App
{
    public class Room3 : IRoom
    {
        public void Enter(Game game)
        {
            Console.WriteLine("\nYou see a table with food and drink. Do you:");
            Console.WriteLine("1. Eat, drink, and rest");
            Console.WriteLine("2. Ignore it and move on");
            string choice = game.GetPlayerInput();

            if (choice == "1")
            {
                Console.WriteLine("You feel refreshed!");
                game.AddToInventory("Rested");
            }
            else
            {
                Console.WriteLine("Your injuries and fatigue cause you to fall into a bed of hemlock. You die. Ouch!");
                game.EndGame();
            }
        }
    }

}
