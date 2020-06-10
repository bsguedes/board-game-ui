using BoardGameClient.Lobby;
using System.Windows;
using System.Windows.Controls;

namespace BoardGameClient
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameLoaderViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            this._viewModel = new GameLoaderViewModel();
            this.Title = $"Board Game Client - {Common.Helpers.GetVersion()}";
            DataContext = this._viewModel;
#if DEBUG
            this._viewModel.ServerIP = "http://localhost:5000";
#else
            this._viewModel.ServerIP = "https://boardgames-server.herokuapp.com/";
#endif
        }

        private async void JoinMatch_Click(object sender, RoutedEventArgs e)
        {
            MatchDescriptor match = await _viewModel.JoinMatch();            
            Window _lobbyWindow = new LobbyWindow(match) { Owner = this };
            _lobbyWindow.ShowDialog();
        }
    
        private async void HostMatch_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.ValidateOptions())
            {
                MatchDescriptor match = await _viewModel.HostMatch();
                Window _lobbyWindow = new LobbyWindow(match) { Owner = this };
                _lobbyWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please check the game settings.", "Error");
            }
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

        private async void RegisterPlayer_Click(object sender, RoutedEventArgs e)
        {            
            bool registerSuccess = await _viewModel.RegisterPlayer();
            if (!registerSuccess)
            {
                MessageBox.Show("User name contains invalid characters.", "Error");
            }            
        }
    }
}
