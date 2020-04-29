using BoardGameClient.Lobby;
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

namespace BoardGameClient
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameLoaderViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            this._viewModel = new GameLoaderViewModel();
            DataContext = this._viewModel;
            this._viewModel.ServerIP = "http://127.0.0.1:5000";
        }

        private async void JoinMatch_Click(object sender, RoutedEventArgs e)
        {
            MatchDescriptor match = await _viewModel.JoinMatch();
            Window _lobbyWindow = new LobbyWindow(match) { Owner = this };
            _lobbyWindow.ShowDialog();
        }
    
        private async void HostMatch_Click(object sender, RoutedEventArgs e)
        {
            MatchDescriptor match = await _viewModel.HostMatch();
            Window _lobbyWindow = new LobbyWindow(match) { Owner = this };
            _lobbyWindow.ShowDialog();
        }        

        private void FindMatches_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.FindMatches();
        }

        private void SelectedGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            optionsGrid.Children.Clear();
            optionsGrid.Children.Add(this._viewModel.SelectedGame.OptionsView.AsUserControl());
        }

        private void RegisterPlayer_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RegisterPlayer();
        }
    }
}
