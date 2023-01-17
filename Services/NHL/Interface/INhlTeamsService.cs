using Tietoa.Domain.Models.Teams;

namespace Services.NHL.Interface

{
    public interface INhlTeamsService
    {
        Task<List<TeamDto>> TeamsRequest();
    }
}
