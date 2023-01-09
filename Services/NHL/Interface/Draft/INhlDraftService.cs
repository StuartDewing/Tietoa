using Tietoa.Domain.Models.Draft;

namespace Services.NHL.Interface.Draft

{
    public interface INhlDraftService
    {
        Task<List<DraftByYearDto>> DraftByYearRequest(int year);
        Task<List<DraftByYearDto>> DraftByTeamRequest(int year, string teamName);
    }
}
