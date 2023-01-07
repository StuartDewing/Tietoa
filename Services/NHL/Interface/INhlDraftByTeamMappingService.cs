using Tietoa.Domain.Models.Draft;

namespace Services.NHL.Interface

{
    public interface INhlDraftTeamMappingService
    {
        Task<List<DraftByYearDto>> MapDraftByTeam(string response, string teamName);
    }
}
