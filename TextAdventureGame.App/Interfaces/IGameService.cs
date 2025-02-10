using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame.App.Interfaces
{
    public interface IGameService
    {
        void Play();
        void ProcessRoom(IRoom room);
    }

}
