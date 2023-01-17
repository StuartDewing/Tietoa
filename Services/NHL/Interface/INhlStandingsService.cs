using Tietoa.Domain.Models.Standings;

namespace Services.NHL.Interface

{
    public interface INhlStandingsService
    {
        Task<List<StandingsDto>> StandingsRequest();
        Task<List<StandingsDto>> StandingsTeamRequest(string team);
    }
}


