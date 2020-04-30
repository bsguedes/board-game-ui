using BoardGameClient.Common;
using BoardGameClient.TicTacToe.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoardGameClient.TicTacToe
{
    public class TicTacToeGame : Game
    {
        public override string Name => "Tic Tac Toe";        

        private TicTacToeViewModel _model;

        protected override IBoardGameOptionsView BuildOptionsView()
        {
            return new TicTacToeOptionsView();
        }

        protected override Window CreateGameWindow()
        {
            return new TicTacToeView(_model);
        }

        protected override ViewModelBase CreateGameViewModel(MatchDescriptor match)
        {          
            _model = new TicTacToeViewModel(match);
            return _model;
        }
    }
}
