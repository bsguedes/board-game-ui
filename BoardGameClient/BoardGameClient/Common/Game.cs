using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoardGameClient.Common
{
    public abstract class Game
    {
        public abstract string Name { get; }
        internal string ID { get; private set; }

        protected abstract IBoardGameOptionsView BuildOptionsView();
        protected abstract Window CreateGameWindow();
        protected abstract ViewModelBase CreateGameViewModel(MatchDescriptor match);
        
        protected ViewModelBase ViewModel;

        private static IBoardGameOptionsView _optionsView;
        public IBoardGameOptionsView OptionsView
        {
            get
            {
                if (_optionsView == null)
                {
                    _optionsView = BuildOptionsView();
                }
                return _optionsView;
            }
        }

        private Window _window;
        public Window Window
        {
            get
            {
                if (_window == null)
                {
                    _window = this.CreateGameWindow();
                }
                return _window;
            }
        }

        internal static Game CreateGame(string gameName)
        {
            switch (gameName)
            {
                case "Tic Tac Toe":
                    return new TicTacToe.TicTacToeGame();
            }
            return null;
        }

        internal void SetupGame(MatchDescriptor match)
        {
            this.ID = match.MatchId;
            this.ViewModel = this.CreateGameViewModel(match);
        }
    }
}
