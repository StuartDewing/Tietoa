using Services.GetRequest.Interface;
using Services.NHL.Interface;

namespace Services.NHL

{
    public class NhlRequest : INhlRequest
    {
        private readonly IGetRequest _GetRequest;
        private const string baseUrl = "https://api-web.nhle.com/v1/";

        public NhlRequest(IGetRequest getRequest)
        {
            _GetRequest = getRequest;
        }

        public async Task<string> NhlApiResponse(string urlSegment)
        {
            string url = baseUrl + urlSegment;
            var response = await _GetRequest.DownloadResponse(url);

            return response;
        }
    }
}