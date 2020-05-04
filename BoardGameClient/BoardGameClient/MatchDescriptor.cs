using BoardGameConnector;
using BoardGameClient.Common;

namespace BoardGameClient
{
    public class MatchDescriptor
    {
        public string Game { get; set; }
        public string SetupSummary { get; set; }
        public int MaxPlayers { get; set; }
        public string HostPlayer { get; set; }
        public string[] CurrentPlayers { get; set; }        
        public int[] CurrentPings { get; set; }
        public string Status { get; set; } 
        public string MatchId { get; set; }        
    }    

    public class NewMatchPayload : ConnectorPayloadBase
    {
        public NewMatchPayload(string playerName, OptionsBase options)
        {
            Options = options;
            Player = playerName;
        }

        public object Options { get; set; }
    }

    public class OptionPayload : ConnectorPayloadBase
    {       
        public OptionPayload(string playerName, string optionCode = "None")
        {
            Player = playerName;
            OptionCode = optionCode;
        }

        public string OptionCode { get; set; }        
    }

    public class NetworkPayload : ConnectorPayloadBase
    {
        public NetworkPayload(string playerName, int playerPing)
        {
            Player = playerName;
            Ping = playerPing;
        }

        public int Ping { get; set; }
    }
}
