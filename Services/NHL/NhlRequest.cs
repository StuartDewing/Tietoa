using Services.GetRequest;

namespace Services.NHL.NhlRequest
{
    public class NhlRequest : INhlRequest
    {
        private readonly IGetRequest _GetRequest;
        private const string baseUrl = "https://statsapi.web.nhl.com/api/v1/";

        public NhlRequest(IGetRequest getRequest)
        {
            _GetRequest = getRequest;
        }

        public async Task<string> NhlGetResponse(string urlSegment)
        {
            string url = baseUrl + urlSegment;

            var response = await _GetRequest.DownloadResponse(url);

            return response;
        }
    }
}