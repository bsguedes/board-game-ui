using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;
using System.Threading.Tasks;
using BoardGameConnector;
using System.Windows;
using BoardGameClient.Common;

namespace BoardGameClient.Lobby
{
    public class LobbyViewModel : ViewModelBase
    {
        private MatchDescriptor _match;

        internal bool PollingCancelled { get; set; }       

        public LobbyViewModel(MatchDescriptor match)
        {
            _match = match;            
        }

        internal async void StartPolling()
        {
            while (true)
            {
                IEnumerable<MatchDescriptor> currentStatus = await GameLoader.Instance.LoadMatchesFromServer();
                _match = currentStatus.FirstOrDefault(x => x.MatchId == _match.MatchId);
                if (_match != null)
                {
                    MaxPlayers = _match.MaxPlayers;
                    IsGameReady = _match.CurrentPlayers.Length == _match.MaxPlayers;
                    IsHost = (_match.HostPlayer == GameLoader.Instance.Player.Name);
                    CurrentPlayerCount = _match.CurrentPlayers.Length;
                    DisplayText = IsGameReady ? "Game is ready to start!" : "Waiting for players...";
                    if (!IsHost && _match.Status == "Started")
                    {
                        PollingCancelled = true;
                        GameStarted(null, null);
                    }
                }
                if (PollingCancelled || (IsGameReady && IsHost))
                {
                    break;
                }
                await Task.Delay(1000);
            }
        }

        internal Window GameWindow()
        {
            Game game = Game.CreateGame(_match.Game);
            game.SetupGame(_match);
            Window w = game.Window;
            return w;
        }

        internal async Task<bool> StartGame()
        {
            if (IsHost)
            {
                _ = await GameLoader.Instance.StartMatch(_match);
                return true;
            }
            return false;
        }

        public event EventHandler GameStarted;

        private int _currentPlayerCount;
        public int CurrentPlayerCount
        {
            get { return _currentPlayerCount; }
            set { SetProperty(ref _currentPlayerCount, value); }
        }

        private int _maxPlayers;
        public int MaxPlayers
        {
            get { return _maxPlayers; }
            set { SetProperty(ref _maxPlayers, value); }
        }

        private bool _isGameReady;
        public bool IsGameReady
        {
            get { return _isGameReady; }
            set { SetProperty(ref _isGameReady, value); }
        }

        private string _displayText;
        public string DisplayText
        {
            get { return _displayText; }
            set { SetProperty(ref _displayText, value); }
        }

        private bool _isHost;
        public bool IsHost
        {
            get { return _isHost; }
            set { SetProperty(ref _isHost, value); }
        }        
    }
}        

