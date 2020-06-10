using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BoardGameClient.TicTacToe
{    
    public partial class TicTacToeView : Window
    {
        private readonly TicTacToeViewModel _viewModel;

        public TicTacToeView(TicTacToeViewModel vm)
        {
            InitializeComponent();            
            DataContext = vm;
            this._viewModel = vm;
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string optionCode = b.Tag as string;
            _viewModel.SelectCell(optionCode);
        }

        protected override void OnClosed(EventArgs e)
        {
            this._viewModel.PollingCancelled = true;
            base.OnClosed(e);
        }
    }
}
