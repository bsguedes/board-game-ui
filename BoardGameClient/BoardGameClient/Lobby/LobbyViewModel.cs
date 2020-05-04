using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;
using System.Threading.Tasks;
using BoardGameConnector;
using System.Windows;
using BoardGameClient.Common;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace BoardGameClient.Lobby
{
    public class LobbyViewModel : ViewModelBase
    {
        private MatchDescriptor _match;

        internal bool PollingCancelled { get; set; }       

        public LobbyViewModel(MatchDescriptor match)
        {
            _match = match;
            GameName = match.Game;
            PlayerList = new ObservableCollection<Tuple<string, int>>();            
        }

        internal async void StartPolling()
        {
            while (true)
            {
                if (PollingCancelled)
                {
                    break;
                }
                Stopwatch timer = new Stopwatch();
                timer.Start();
                IEnumerable<MatchDescriptor> currentStatus = await GameLoader.Instance.LoadMatchesFromServer(true);
                timer.Stop();
                Ping = (int)timer.ElapsedMilliseconds;
                GameLoader.Instance.Player.Ping = Ping;
                _match = currentStatus.FirstOrDefault(x => x.MatchId == _match.MatchId);
                if (_match != null)
                {
                    MaxPlayers = _match.MaxPlayers;
                    IsGameReady = _match.CurrentPlayers.Length == _match.MaxPlayers;
                    IsHost = (_match.HostPlayer == GameLoader.Instance.Player.Name);
                    CurrentPlayerCount = _match.CurrentPlayers.Length;
                    PlayerList.Clear();
                    foreach ((string name, int ping) in _match.CurrentPlayers.Zip(_match.CurrentPings))
                    {
                        PlayerList.Add(new Tuple<string, int>(name, ping));                        
                    }
                    DisplayText = IsGameReady ? "Game is ready to start!" : "Waiting for players...";
                    if (_match.Status == "Started")
                    {
                        PollingCancelled = true;
                        if (!IsHost)
                        {
                            GameStarted();
                        }
                    }                    
                }
                else
                {
                    PollingCancelled = true;
                    GameAborted();
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
                GameStarted();
                return true;
            }
            return false;
        }

        internal async Task<bool> QuitGame()
        {            
            _ = await GameLoader.Instance.QuitMatch(_match);
            PollingCancelled = true;
            return true;
        }

        public event GameStartEventHandler GameStarted;
        public event GameAbortedEventHandler GameAborted;

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

        private int _ping;
        public int Ping
        {
            get { return _ping; }
            set { SetProperty(ref _ping, value); }
        }

        public ObservableCollection<Tuple<string, int>> PlayerList { get; set; }

        public string GameName { get; }
    }
}        

