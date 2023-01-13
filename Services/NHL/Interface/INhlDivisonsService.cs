using Tietoa.Domain.Models.Divisions;

namespace Services.NHL.Interface

{
    public interface INhlDivisionsService
    {
        Task<List<DivisionsDto>> DivisionsRequest();
    }
}
