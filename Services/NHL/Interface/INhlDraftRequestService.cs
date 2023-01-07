using Tietoa.Domain.Models.Draft;

namespace Services.NHL.Interface

{
    public interface INhlDraftRequestService
    {
        Task<List<DraftByYearDto>> GetDraft(int year);
        Task<List<DraftByYearDto>> GetDraftByTeam(int year, string teamName);
    }
}
