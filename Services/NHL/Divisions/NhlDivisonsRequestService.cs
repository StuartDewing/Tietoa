using Services.NHL.Interface;
using Services.NHL.Interface.Divisions;
using Tietoa.Domain.Models.Divisions;

namespace Services.NHL.Divisions

{
    public class NhlDivisionsRequestService : INhlDivisionsRequestService
    {
        private readonly INhlRequest _NhlRequest;
        private readonly INhlDivisionsMappingService _NhlDivisionsMappingService;

        private async Task<string> nhlDivisionsRequest()
        {
            string urlSegment = $"divisions";
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            return response;
        }

        public NhlDivisionsRequestService(INhlRequest nhlRequest, INhlDivisionsMappingService nhlDivisonsMappingService)
        {
            _NhlRequest = nhlRequest;
            _NhlDivisionsMappingService = nhlDivisonsMappingService;
        }

        public async Task<List<DivisionsDto>> GetDivisions()
        {
            var response = await nhlDivisionsRequest();
            var nhlDivisonsDto = await _NhlDivisionsMappingService.MapDivisions(response);

            return nhlDivisonsDto;
        }
    }
}