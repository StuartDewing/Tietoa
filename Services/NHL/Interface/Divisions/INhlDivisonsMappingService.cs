using Tietoa.Domain.Models.Divisions;

namespace Services.NHL.Interface.Divisions

{
    public interface INhlDivisionsMappingService
    {
        Task<List<DivisionsDto>> MapDivisions(string response);
    }
}
