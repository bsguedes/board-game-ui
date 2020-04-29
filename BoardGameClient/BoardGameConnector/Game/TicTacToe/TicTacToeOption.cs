using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameConnector.Game.TicTacToe
{
    public class TicTacToeOption : GameOption
    {
        public int X { get; }
        public int Y { get; }

        public TicTacToeOption(string text, int x, int y) 
            : base(text)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
