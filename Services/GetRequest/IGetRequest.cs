using Tietoa.Domain.Models.Player.JsonClasses;

namespace Services.GetRequest
{
    public interface IGetRequest
    {
        Task<string?> DownloadResponse(string url);
    }
}
