using Tietoa.Domain.Models.Divisions;

namespace Services.NHL.Interface.Divisions

{
    public interface INhlDivisionsService
    {
        Task<List<DivisionsDto>> DivisionsRequest();
    }
}
