namespace Services.GetRequest.Interface

{
    public interface IGetRequest
    {
        Task<string> DownloadResponse(string url);
    }
}