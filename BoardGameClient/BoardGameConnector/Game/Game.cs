using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameConnector.Game
{
    public abstract class Game
    {
        public GameSetup Setup { get; protected set; }

        public Game()
        {

        }

        public abstract object NewGame();        
    }
}
