using Tietoa.Domain.Models.Player;

namespace Services.NHL.Player.Interface

{
    public interface INhlPlayerService222
    {
        Task<List<PlayerDto>> PlayerRequest(PlayerRequestModel request);
    }
}
