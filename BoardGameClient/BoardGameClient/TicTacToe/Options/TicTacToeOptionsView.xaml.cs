using BoardGameClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardGameClient.TicTacToe.Options
{
    /// <summary>
    /// Interação lógica para TicTacToeOptionsView.xaml
    /// </summary>
    public partial class TicTacToeOptionsView : UserControl, IBoardGameOptionsView
    {
        private TicTacToeOptionsViewModel _ticTacToeOptionsViewModel;

        public TicTacToeOptionsView()
        {
            InitializeComponent();
            this._ticTacToeOptionsViewModel = new TicTacToeOptionsViewModel();
            this.DataContext = this._ticTacToeOptionsViewModel;
        }

        public OptionsViewModelBase ViewModel => _ticTacToeOptionsViewModel;

        public UserControl AsUserControl()
        {
            return this;
        }

        public OptionsBase GetOptions()
        {
            return _ticTacToeOptionsViewModel.LoadCurrentOptions();
        }
    }
}
