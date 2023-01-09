using Services.NHL.Interface;
using Services.NHL.Interface.Draft;
using Tietoa.Domain.Models.Draft;

namespace Services.NHL.Draft

{
    public class NhlDraftRequestService : INhlDraftRequestService
    {
        private readonly INhlRequest _NhlRequest;
        private readonly INhlDraftMappingService _NhlDraftMappingService;
        private readonly INhlDraftTeamMappingService _NhlDraftTeamMappingService;

        private async Task<string> nhlDraftRequest(int year)
        {
            string urlSegment = $"draft/{year}";
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            return response;
        }

        public NhlDraftRequestService(INhlRequest nhlRequest, INhlDraftMappingService nhlDraftMappingService, INhlDraftTeamMappingService nhlDraftTeamMappingService)
        {
            _NhlRequest = nhlRequest;
            _NhlDraftMappingService = nhlDraftMappingService;
            _NhlDraftTeamMappingService = nhlDraftTeamMappingService;
        }

        public async Task<List<DraftByYearDto>> GetDraft(int year)
        {
            var response = await nhlDraftRequest(year);
            var nhlDraftDto = await _NhlDraftMappingService.MapDraftByYear(response);

            return nhlDraftDto;
        }

        public async Task<List<DraftByYearDto>> GetDraftByTeam(int year, string teamName)
        {
            var response = await nhlDraftRequest(year);
            var nhlDraftDto = await _NhlDraftTeamMappingService.MapDraftByTeam(response, teamName);

            return nhlDraftDto;
        }
    }
}