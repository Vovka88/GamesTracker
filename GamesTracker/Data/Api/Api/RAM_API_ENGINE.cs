using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GamesObserver.Data.Api
{
    internal class RAM_API_ENGINE
    {
        private string s_matchBaseUri = "https://api.opendota.com/api/matches/";
        private HttpClient client { get; set; }
        public RAM_API_ENGINE()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(s_matchBaseUri);
        }

        //public async Task<string> GetMatchResultsAsync(string n_matchId)
        //{
        //    using (var response = await client.GetAsync(s_matchBaseUri + n_matchId))
        //    {
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //}

        public string GetMatchResults(string n_matchId)
        {
            var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, s_matchBaseUri + n_matchId));
            var content = response.Result.Content.ReadAsStringAsync();
            return content.Result.ToString();
        }
    }
}
