using Tietoa.Domain.Models.Draft;

namespace Services.NHL.Interface.Draft

{
    public interface INhlDraftTeamMappingService
    {
        Task<List<DraftByYearDto>> MapDraftByTeam(string response, string teamName);
    }
}
