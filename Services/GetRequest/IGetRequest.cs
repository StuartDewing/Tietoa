namespace Services.GetRequest
{
    public interface IGetRequest
    {
        Task<string> DownloadResponse(string url);
    }
}