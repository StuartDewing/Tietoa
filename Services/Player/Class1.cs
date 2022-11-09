using /Microsoft.AspNetCore.Mvc;
using /Newtonsoft.Json;
using /Tietoa.Models.Player;
using Tietoa.Models.Player.JsonClasses;

namespace Services.Player
{
    private static async Task<PlayerResponse> NewMethod(int id)
    {
        var url = $"https://statsapi.web.nhl.com/api/v1/people/{id}";
        var response = await _httpClient.GetAsync(url);
        var responseString = await response.Content.ReadAsStringAsync();
        PlayerResponse playerResponse = JsonConvert.DeserializeObject<PlayerResponse>(responseString);
        return playerResponse;
    }
}