using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame.App.Interfaces;

namespace TextAdventureGame.App
{
    public class Room5 : IRoom
    {
        public void Enter(Game game)
        {
            Console.WriteLine("\nYou reach a library. Do you:");
            Console.WriteLine("1. Return an overdue book");
            Console.WriteLine("2. Borrow a recommended book");
            string choice = game.GetPlayerInput();

            if (choice == "1")
                game.LoseHeart();
        }
    }
}
