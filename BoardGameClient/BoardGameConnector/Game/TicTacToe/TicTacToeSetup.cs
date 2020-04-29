using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameConnector.Game.TicTacToe
{
    public class TicTacToeSetup : GameSetup
    {
        public int Width { get; }
        public int Height { get; }
        public int Connect { get; }

        public TicTacToeSetup(int w, int h, int c)
            : base()
        {
            this.Width = w;
            this.Height = h;
            this.Connect = c;
        }
    }
}
