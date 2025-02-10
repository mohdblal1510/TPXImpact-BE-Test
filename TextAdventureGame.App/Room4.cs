using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame.App.Interfaces;

namespace TextAdventureGame.App
{
    public class Room4 : IRoom
    {
        public void Enter(Game game)
        {
            Console.WriteLine("\nYou are in a beer cellar. Do you:");
            Console.WriteLine("1. Accept a beer");
            Console.WriteLine("2. Decline and ask for the W.C.");
            string choice = game.GetPlayerInput();

            if (choice == "1")
                game.LoseHeart();
        }
    }
}
