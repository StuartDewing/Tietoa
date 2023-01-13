using Tietoa.Domain.Models.Player;

namespace Services.NHL.Interface

{
    public interface INhlPlayerService
    {
        Task<List<PlayerDto>> PlayerRequest(int playerId);
    }
}
