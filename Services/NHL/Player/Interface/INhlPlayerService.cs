using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Player;

namespace Services.NHL.Player.Interface

{
    public interface INhlPlayerService
    {
        Task<List<PlayerDto>> PlayerRequest(int playerId);
    }
}
