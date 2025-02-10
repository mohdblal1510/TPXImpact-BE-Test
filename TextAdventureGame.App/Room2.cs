using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame.App.Interfaces;

namespace TextAdventureGame.App
{
    public class Room2 : IRoom
    {
        public void Enter(Game game)
        {
            Console.WriteLine("\nYou find two doors. Do you:");
            Console.WriteLine("1. Go through the right-hand door");
            Console.WriteLine("2. Go through the left-hand door");
            string choice = game.GetPlayerInput();

            if (choice == "1")
                game.LoseHeart();
        }
    }
}
