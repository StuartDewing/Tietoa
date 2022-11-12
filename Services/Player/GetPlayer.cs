using Newtonsoft.Json;
using Tietoa.Domain.Models.Player.JsonClasses;

namespace Services.Player
{
    public class GetPlayer : IGetPlayer
    {
        public async Task<PlayerResponse> DownloadPlayer(int id)
        {
            var _httpClient = new HttpClient();

            var url = $"https://statsapi.web.nhl.com/api/v1/people/{id}";
            var response = await _httpClient.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();
            PlayerResponse playerResponse = JsonConvert.DeserializeObject<PlayerResponse>(responseString);
            return playerResponse;
        }
    } 
}