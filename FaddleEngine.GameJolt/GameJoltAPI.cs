using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace FaddleEngine.GameJolt
{
    public class GameJoltAPI : FaddlePackage
    {
        private const string BASE_URL = "https://api.gamejolt.com/api/game/v1_2/";

        private readonly string gameId = "";
        private readonly string privateKey = "";

        private readonly HttpClient http;

        public GameJoltAPI(string gameId, string privateKey) : base("GameJolt")
        {
            this.gameId = gameId;
            this.privateKey = privateKey;
            this.http = new HttpClient();
        }

        public bool Login(string username, string token)
        {
            string url = $"{BASE_URL}users/?game_id={gameId}&username={username}&user_token={token}";

            string signature = url + privateKey;

            byte[] hash = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(signature));
            StringBuilder sb = new(hash.Length * 2);

            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            signature = sb.ToString();

            Log.Info(signature);

            url += $"&signature={signature}";

            string response = SendRequest(url);

            Log.Info(response);

            return true;
        }

        private string SendRequest(string url)
        {
            HttpRequestMessage request = new(HttpMethod.Get, url);

            HttpResponseMessage response = http.Send(request);

            using StreamReader reader = new(response.Content.ReadAsStream());

            return reader.ReadToEnd();
        }

        public override void OnAdd()
        {
        }

        public override void OnQuit()
        {
        }

        public override void OnRender()
        {
        }

        public override void OnUpdate()
        {
        }
    }
}