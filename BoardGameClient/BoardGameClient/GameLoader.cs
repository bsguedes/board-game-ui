using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BoardGameClient.Common;
using BoardGameConnector;
using System;

namespace BoardGameClient
{
    internal sealed class GameLoader
    {
        static GameLoader() { }
        Connector _gameServer;

        private GameLoader()
        {
            _gameServer = new Connector();               
        }        

        public static GameLoader Instance { get; } = new GameLoader();
        public PlayerDescriptor Player { get; internal set; }
        public string CurrentMatchID { get; private set; }

        internal async Task<IEnumerable<MatchDescriptor>> LoadMatchesFromServer(bool fromLobby)
        {
            Endpoint e = Endpoint.Matchlist(fromLobby);
            ConnectorPayloadBase payload = new NetworkPayload(Player.Name, Player.Ping);
            return await _gameServer.PostJSON<IEnumerable<MatchDescriptor>>(e, payload);
        }        

        internal async Task<StateDescriptor<S, O>> LoadStateForPlayer<S, O>(string matchId, string secret)
            where S : GameStateDescriptor
            where O : GameOptionsDescriptor
        {
            Endpoint e = Endpoint.GetState(matchId, secret);
            return await _gameServer.GetJSON<StateDescriptor<S, O>>(e);
        }

        internal async Task<PlayerDescriptor> SelectOption(string optionCode)
        {
            Endpoint e = Endpoint.ChooseOption(CurrentMatchID, Player.Secret);
            ConnectorPayloadBase payload = new OptionPayload(Player.Name, optionCode);
            return await _gameServer.PostJSON<PlayerDescriptor>(e, payload);            
        }

        internal async Task<MatchDescriptor> HostMatch(string gameName, OptionsBase options)
        {
            Endpoint e = Endpoint.NewGame(_gameServer.TranslateGameName(gameName), Player.Secret);
            ConnectorPayloadBase payload = new NewMatchPayload(Player.Name, options);            
            MatchDescriptor match = await _gameServer.PostJSON<MatchDescriptor>(e, payload);
            CurrentMatchID = match.MatchId;
            return match;
        }

        internal async Task<PlayerDescriptor> RegisterPlayer(string address, string playerName)
        {
            _gameServer.SetAddress(address);
            Endpoint e = Endpoint.RegisterPlayer(playerName);
            return await _gameServer.GetJSON<PlayerDescriptor>(e);
        }

        internal async Task<MatchDescriptor> JoinMatch(MatchDescriptor selectedMatch)
        {
            Endpoint e = Endpoint.JoinMatch(selectedMatch.MatchId);
            ConnectorPayloadBase payload = new OptionPayload(Player.Name);
            CurrentMatchID = selectedMatch.MatchId;
            return await _gameServer.PostJSON<MatchDescriptor>(e, payload);
        }

        internal async Task<PlayerDescriptor> QuitMatch(MatchDescriptor match)
        {
            Endpoint e = Endpoint.QuitMatch(match.MatchId, Player.Secret);
            ConnectorPayloadBase payload = new OptionPayload(Player.Name);
            PlayerDescriptor response = await _gameServer.PostJSON<PlayerDescriptor>(e, payload);
            return response;
        }

        internal async Task<PlayerDescriptor> StartMatch(MatchDescriptor match)
        {
            Endpoint e = Endpoint.StartMatch(match.MatchId, Player.Secret);
            ConnectorPayloadBase payload = new OptionPayload(Player.Name);            
            PlayerDescriptor response = await _gameServer.PostJSON<PlayerDescriptor>(e, payload);            
            return response;
        }
    }    
}
