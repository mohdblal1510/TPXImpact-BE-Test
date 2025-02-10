using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame.App.Interfaces;

namespace TextAdventureGame.App
{
    public class Room1 : IRoom
    {
        public void Enter(Game game)
        {
            Console.WriteLine("\nYou are in a dungeon. A goblin stares at you menacingly.");
            Console.WriteLine("1. Attack the goblin");
            Console.WriteLine("2. Run away");
            string choice = game.GetPlayerInput();

            if (choice == "1")
                game.LoseHeart();
        }
    }
}
