using Tietoa.Domain.Models.Draft;

namespace Services.NHL

{
    public interface INhlDraftService
    {
        Task<List<DraftByYearDto>> GetDraftByYear(int year);
    }
}
