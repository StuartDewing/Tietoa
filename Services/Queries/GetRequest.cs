using Services.GetRequest.Interface;

namespace Services.GetRequest

{
    public class GetRequest : IGetRequest
    {
        public async Task<string> DownloadResponse(string url)
        {
            var _httpClient = new HttpClient();
            var response = await _httpClient.GetStringAsync(url);

            return response;
        }
    }
}