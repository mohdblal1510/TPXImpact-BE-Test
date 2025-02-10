using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame.App.Interfaces;

namespace TextAdventureGame.App
{
    public class Game
    {
        public int Hearts { get; private set; }
        public Dictionary<string, bool> Inventory { get; private set; }
        private readonly IPlayerInput _playerInput;

        public Game(IPlayerInput playerInput)
        {
            _playerInput = playerInput;
            Hearts = 3;
            Inventory = new Dictionary<string, bool>();
        }

        public string GetPlayerInput() => _playerInput.GetInput();

        public void LoseHeart()
        {
            Hearts--;
        }

        public bool IsGameOver() => Hearts <= 0;
    }
}
