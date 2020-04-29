using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameConnector.Game.TicTacToe
{
    public class TicTacToeGame : Game
    {        
        public TicTacToeGame(TicTacToeSetup setup)
        {
            this.Setup = setup;
        }

        public override object NewGame()
        {
            throw new NotImplementedException();
        }
    }

    public enum Symbol
    {
        X,
        O,
        None
    }
}
