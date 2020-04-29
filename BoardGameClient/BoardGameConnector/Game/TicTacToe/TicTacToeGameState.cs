using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameConnector.Game.TicTacToe
{
    public class TicTacToeGameState : GameState
    {
        public Symbol[][] Board { get; } 

        public TicTacToeGameState(Symbol[][] board)
        {
            this.Board = board;
        }
    }
}
