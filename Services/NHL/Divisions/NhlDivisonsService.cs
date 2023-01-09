using Services.NHL.Interface.Divisions;
using Tietoa.Domain.Models.Divisions;

namespace Services.NHL.Divisions

{
    public class NhlDivisionsService : INhlDivisionsService
    {
        private readonly INhlDivisionsRequestService _NhlDivisionsRequestService;

        public NhlDivisionsService(INhlDivisionsRequestService nhlDivisonsRequestService)
        {
            _NhlDivisionsRequestService = nhlDivisonsRequestService;
        }

        public async Task<List<DivisionsDto>> DivisionsRequest()
        {
            var nhlDivisionsDto = await _NhlDivisionsRequestService.GetDivisions();

            return nhlDivisionsDto;
        }
    }
}