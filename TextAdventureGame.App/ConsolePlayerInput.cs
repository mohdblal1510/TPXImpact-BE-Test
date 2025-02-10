    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame.App.Interfaces;

namespace TextAdventureGame.App
{
    public class ConsolePlayerInput : IPlayerInput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
