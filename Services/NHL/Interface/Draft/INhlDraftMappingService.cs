using Tietoa.Domain.Models.Draft;

namespace Services.NHL.Interface.Draft

{
    public interface INhlDraftMappingService
    {
        Task<List<DraftByYearDto>> MapDraftByYear(string response);
    }
}
