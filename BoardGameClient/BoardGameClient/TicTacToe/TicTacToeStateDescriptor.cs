using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClient.TicTacToe
{
    public class TicTacToeStateDescriptor : GameStateDescriptor
    {
        public bool?[][] Board { get; set; }
        public string Message { get; set; }
    }

    public class TicTacToeOptionDescriptor : GameOptionsDescriptor
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
