using Tietoa.Domain.Models.Draft;

namespace Services.NHL.Interface

{
    public interface INhlDraftService
    {
        Task<List<DraftDto>> DraftByYearRequest(int year);
        Task<List<DraftDto>> DraftByTeamRequest(int year, string teamName);
    }
}
