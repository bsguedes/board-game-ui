using BoardGameClient.Common;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BoardGameClient
{
    public class GameLoaderViewModel : ViewModelBase
    {
        public GameLoaderViewModel()
        {
            MatchList = new ObservableCollection<MatchDescriptor>();
        }

        private string _serverIP;
        public string ServerIP
        {
            get { return _serverIP; }
            set { SetProperty(ref _serverIP, value); }
        }

        private string _playerName;
        public string PlayerName
        {
            get { return _playerName; }
            set { SetProperty(ref _playerName, value); }
        }

        private bool _isSuccessfullyRegistered;
        public bool IsSuccessfullyRegistered
        {
            get { return _isSuccessfullyRegistered; }
            set { SetProperty(ref _isSuccessfullyRegistered, value); }
        }

        public string[] AvailableGames => new string[] { "Tic Tac Toe" };

        private string _selectedNewGame;
        public string SelectedNewGame
        {
            get { return _selectedNewGame; }
            set { SetProperty(ref _selectedNewGame, value); }
        }

        public ObservableCollection<MatchDescriptor> MatchList { get; }

        internal bool ValidateOptions()
        {
            return SelectedGame?.OptionsView.ViewModel.VerifyOptions() ?? false;
        }

        private MatchDescriptor _selectedMatch;
        public MatchDescriptor SelectedMatch
        {
            get { return _selectedMatch; }
            set { SetProperty(ref _selectedMatch, value); }
        }

        readonly Dictionary<string, Game> _gameOptions = new Dictionary<string, Game>();
        internal Game SelectedGame
        {
            get
            {
                if (!_gameOptions.ContainsKey(SelectedNewGame))
                {
                    _gameOptions[SelectedNewGame] = Game.CreateGame(SelectedNewGame);
                }
                return _gameOptions[SelectedNewGame];
            }
        }

        internal async void FindMatches()
        {
            this.MatchList.Clear();
            IEnumerable<MatchDescriptor> matches = await GameLoader.Instance.LoadMatchesFromServer(false);
            foreach (MatchDescriptor match in matches)
            {
                this.MatchList.Add(match);
            }
        }

        internal async Task<MatchDescriptor> HostMatch()
        {
            MatchDescriptor match = await GameLoader.Instance.HostMatch(SelectedNewGame, SelectedGame.OptionsView.GetOptions());
            return match;
        }

        internal async Task<MatchDescriptor> JoinMatch()
        {
            MatchDescriptor match = await GameLoader.Instance.JoinMatch(SelectedMatch);
            return match;
        }

        internal async Task<bool> RegisterPlayer()
        {
            if (PlayerName.All(char.IsLetterOrDigit))
            {
                PlayerDescriptor player = await GameLoader.Instance.RegisterPlayer(ServerIP, PlayerName);
                GameLoader.Instance.Player = player;
                IsSuccessfullyRegistered = true;
            }
            return IsSuccessfullyRegistered;
        }
    }
}
