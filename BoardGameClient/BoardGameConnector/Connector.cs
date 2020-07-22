using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text;
using System;

namespace BoardGameConnector
{
    public class Connector
    {
        public string Address { get; private set; }
        private readonly HttpClient _server;

        public Connector()
        {
            _server = new HttpClient();
        }

        public void SetAddress(string address)
        {
            while (address.EndsWith("/"))
            {
                address = address.Substring(0, address.LastIndexOf('/'));
            }
            Address = address;
        }

        public async Task<T> GetJSON<T>(Endpoint endPoint)
        {
            try
            {
                string content = await _server.GetStringAsync(endPoint.ComposeAddress(Address));
                T responseBody = JsonSerializer.Deserialize<T>(content);
                return responseBody;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }

        public async Task<T> PostJSON<T>(Endpoint endPoint, ConnectorPayloadBase payload)
        {
            try
            {
                StringContent requestBody = new StringContent(payload.AsJson(), Encoding.UTF8, "application/json");
                var response = await _server.PostAsync(endPoint.ComposeAddress(Address), requestBody);
                string content = await response.Content.ReadAsStringAsync();
                T responseBody = JsonSerializer.Deserialize<T>(content);
                return responseBody;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }    

        public string TranslateGameName(string gameName)
        {
            switch (gameName)
            {
                case "Tic Tac Toe":
                    return "tictactoe";
                case "Classificação Etária":
                    return "ce";
                default:
                    return null;
            }
        }
    }

    public class Endpoint
    {
        public string[] Parts { get; set; }        

        public Endpoint(params string[] parts)
        {
            Parts = parts;
        }

        internal string ComposeAddress(string baseAddress)
        {
            return string.Format("{0}/{1}", baseAddress, string.Join("/", Parts));
        }

        public static Endpoint MatchList(bool from_lobby) => new Endpoint("matches", from_lobby ? "1": "0");
        public static Endpoint PlayerList() => new Endpoint("players");
        public static Endpoint RegisterPlayer(string player_name) => new Endpoint("register", player_name);
        public static Endpoint NewGame(string game, string secret) => new Endpoint("match", "new", game, secret);
        public static Endpoint JoinMatch(string match_id) => new Endpoint("match", match_id, "join");
        public static Endpoint StartMatch(string match_id, string secret) => new Endpoint("match", match_id, "start", secret);
        public static Endpoint QuitMatch(string match_id, string secret) => new Endpoint("match", match_id, "quit", secret);
        public static Endpoint GetState(string match_id, string secret) => new Endpoint("match", match_id, "state", secret);
        public static Endpoint ChooseOption(string match_id, string secret) => new Endpoint("match", match_id, "option", secret);
    }

    public abstract class ConnectorPayloadBase
    {
        public string AsJson()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize<object>(this, options);
        }

        public string Player { get; set; }
    }
}
