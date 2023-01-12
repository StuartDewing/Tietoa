using Tietoa.Domain.Models.Divisions;

namespace Services.NHL.Interface.Divisions

{
    public interface INhlDivisionsRequestService
    {
        Task<List<DivisionsDto>> GetDivisions();
    }
}
