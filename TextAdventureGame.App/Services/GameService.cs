﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame.App.Interfaces;

namespace TextAdventureGame.App.Services
{
    public class GameService : IGameService
    {
        private readonly Game _game;
        private readonly Queue<IRoom> _rooms;

        public GameService(Game game)
        {
            _game = game;
            _rooms = new Queue<IRoom>(new List<IRoom>
        {
            new Room1(),
            new Room2(),
            new Room3(),
            new Room4(),
            new Room5()
        });
        }

        public void Play()
        {
            Console.WriteLine("Welcome to the Text Adventure Game!");
            while (_rooms.Count > 0 && !_game.IsGameOver())
            {
                ProcessRoom(_rooms.Dequeue());
            }

            if (!_game.IsGameOver())
                Console.WriteLine("Congratulations! You have completed the game.");
        }

        public void ProcessRoom(IRoom room)
        {
            room.Enter(_game);
            if (_game.IsGameOver())
            {
                Console.WriteLine("Game Over!");
            }
        }
    }
}
