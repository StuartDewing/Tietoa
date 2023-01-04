using Services.GetRequest;

namespace Services.NHL.NhlRequest
{
    public class NhlRequest : INhlRequest
    {
        private readonly IGetRequest _GetRequest;

        public NhlRequest(IGetRequest getRequest)
        {
            _GetRequest = getRequest;
        }

        public async Task<string> NHLGetResponse(string url)
        {
            var response = await _GetRequest.DownloadResponse(url);

            return response;
        }
    }
}