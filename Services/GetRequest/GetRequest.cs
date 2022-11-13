using Newtonsoft.Json;
using Tietoa.Domain.Models.Player.JsonClasses;

namespace Services.GetRequest
{
    public class GetRequest : IGetRequest
    {
        public async Task<string?> DownloadResponse(string url)
        {
            var _httpClient = new HttpClient();
            var response = await _httpClient.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
    }
}