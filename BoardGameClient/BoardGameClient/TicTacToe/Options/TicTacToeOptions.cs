using BoardGameClient.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameClient.TicTacToe.Options
{
    public class TicTacToeOptions : OptionsBase
    {
        public TicTacToeOptions(int x, int y, int k)
        {
            X = x;
            Y = y;
            K = k;
            MaxPlayers = 2;
        }

        public int X { get; }
        public int Y { get; }
        public int K { get; }
    }

    public class TicTacToeOptionsViewModel : ViewModelBase, IBoardGameOptionsViewModel
    {
        public OptionsBase LoadCurrentOptions()
        {
            return new TicTacToeOptions(X, Y, K);
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

        private int _k;
        public int K
        {
            get { return _k; }
            set { SetProperty(ref _k, value); }
        }

        public int[] AllowedDimension => new int[] { 3, 4, 5, 6, 7, 8 };        
    }
}
