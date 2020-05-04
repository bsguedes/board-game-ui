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
            this._viewModel = new LobbyViewModel(match);
            
            InitializeComponent();                 

            this._viewModel.GameStarted += () => LoadGameUI();
            this._viewModel.GameAborted += () => AbortGame();
            DataContext = this._viewModel;
            this._viewModel.StartPolling();
        }

        private async void ReturnHome_Click(object sender, RoutedEventArgs e)
        {
            bool gameCancelled = await _viewModel.QuitGame();
            _viewModel.PollingCancelled = true;
            this.Close();
        }

        private async void StartGame_Click(object sender, RoutedEventArgs e)
        {
            bool gameCreated = await _viewModel.StartGame();
            if (!gameCreated)            
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

        private void AbortGame()
        {
            this.Close();
            MessageBox.Show("Game ended by the host.", "Error");
        }
    }
}
