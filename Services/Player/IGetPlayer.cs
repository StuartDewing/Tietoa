using Tietoa.Domain.Models.Player.JsonClasses;

namespace Services.Player
{
    public interface IGetPlayer
    {
        Task<PlayerResponse> DownloadPlayer(int id);

    }
}
