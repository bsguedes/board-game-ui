using System.Windows;

namespace BoardGameClient.Lobby
{
    /// <summary>
    /// Interaction logic for LobbyWindow.xaml
    /// </summary>
    public partial class LobbyWindow : Window
    {
        private LobbyViewModel _viewModel;

        public LobbyWindow(MatchDescriptor match)
        {
            InitializeComponent();
            this._viewModel = new LobbyViewModel(match);
            if (!this._viewModel.IsHost)
            {
                this._viewModel.GameStarted += (s, e) => LoadGameUI();
            }
            DataContext = this._viewModel;
            this._viewModel.StartPolling();
        }

        private void ReturnHome_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.PollingCancelled = true;
            this.Close();
        }

        private async void StartGame_Click(object sender, RoutedEventArgs e)
        {
            bool gameCreated = await _viewModel.StartGame();
            if (gameCreated)
            {
                LoadGameUI();
            }
            else
            {
                MessageBox.Show("Game must be started by the host player.", "Error");
            }
        }

        private void LoadGameUI()
        {
            Window _gameWindow = _viewModel.GameWindow();
            _gameWindow.Owner = this.Owner;
            this.Close();
            _gameWindow.ShowDialog();
        }
    }
}
