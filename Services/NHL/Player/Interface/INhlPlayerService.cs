using Tietoa.Domain.Models.Player;

namespace Services.NHL.Player.Interface

{
    public interface INhlPlayerService
    {
        Task<List<PlayerDto>> PlayerRequest(PlayerRequestModel request);
    }
}
