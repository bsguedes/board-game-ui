using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameClient.TicTacToe
{
    public class TicTacToeViewModel : GameViewModelBase
    {
        Dictionary<bool, string> _symbols = new Dictionary<bool, string>();

        public TicTacToeViewModel(MatchDescriptor match) : base(match)
        {            
            StartPollingState<TicTacToeStateDescriptor, TicTacToeOptionDescriptor>();
        }

        internal override bool UpdateViewModel<S, O>(StateDescriptor<S, O> state)
        {            
            TicTacToeStateDescriptor descriptor = state.State as TicTacToeStateDescriptor;
            OptionsDescriptor<TicTacToeOptionDescriptor>[] options = state.Options as OptionsDescriptor<TicTacToeOptionDescriptor>[];

            if (state.StateNo == 0 && LastState != 0)
            {
                string you = GameLoader.Instance.Player.Name;
                string other = Match.CurrentPlayers.First(x => x != you);
                CrossPlayer = state.CurrentPlayer == you ? you : other;
                CirclePlayer = CrossPlayer == you ? other : you;
                _symbols.Add(true, CrossPlayer == you ? "X" : "O");
                _symbols.Add(false, CrossPlayer == you ? "O" : "X");
            }                        
            if (Boxes == null)
            {
                Boxes = InitializeBoxes(descriptor.Board);
            }
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Boxes[Y * i + j].IsEnabled = descriptor.Board[i][j] == null && state.CurrentPlayer == GameLoader.Instance.Player.Name;
                    Boxes[Y * i + j].Value = descriptor.Board[i][j].HasValue ?_symbols[descriptor.Board[i][j].Value] : null;
                    Boxes[Y * i + j].OptionCode = options?.FirstOrDefault(x => x.Option.X == i && x.Option.Y == j)?.OptionCode;                        
                }
            }
            if (descriptor.Message != null)
            {
                EndgameMessage = descriptor.Message;
                return true;
            }
            return false;            
        }

        internal void SelectCell(string optionCode)
        {
            SelectOption(optionCode);
        }

        private TicTacToeBox[] InitializeBoxes(bool?[][] board)
        {
            X = board.GetLength(0);
            Y = board[0].Length;
            TicTacToeBox[] boxes = new TicTacToeBox[X * Y];
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    boxes[Y * i + j] = new TicTacToeBox();
                }
            }
            return boxes;
        }

        private string _endgameMessage;
        public string EndgameMessage
        {
            get { return _endgameMessage; }
            set { SetProperty(ref _endgameMessage, value); }
        }

        private string _crossPlayer;
        public string CrossPlayer
        {
            get { return _crossPlayer; }
            set { SetProperty(ref _crossPlayer, value); }
        }

        private string _circlePlayer;
        public string CirclePlayer
        {
            get { return _circlePlayer; }
            set { SetProperty(ref _circlePlayer, value); }
        }

        private TicTacToeBox[] _boxes;
        public TicTacToeBox[] Boxes
        {
            get { return _boxes; }
            set { SetProperty(ref _boxes, value); }
        }

        private int _x;
        public int X
        {
            get { return _x; }
            set { SetProperty(ref _x, value); }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set { SetProperty(ref _y, value); }
        }
    }

    public class TicTacToeBox : ViewModelBase
    {
        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }
        
        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        private string _optionCode;
        public string OptionCode
        {
            get { return _optionCode; }
            set { SetProperty(ref _optionCode, value); }
        }
    }
}
