using Services.NHL.Interface;
using Tietoa.Domain.Models.Draft;

namespace Services.NHL

{
    public class NhlDraftRequestService : INhlDraftRequestService
    {
        private readonly INhlRequest _NhlRequest;
        private readonly INhlDraftMappingService _NhlDraftMappingService;
        private readonly INhlDraftTeamMappingService _NhlDraftTeamMappingService;

        public NhlDraftRequestService(INhlRequest nhlRequest, INhlDraftMappingService nhlDraftMappingService, INhlDraftTeamMappingService nhlDraftTeamMappingService)
        {
            _NhlRequest = nhlRequest;
            _NhlDraftMappingService = nhlDraftMappingService;
            _NhlDraftTeamMappingService = nhlDraftTeamMappingService;
        }

        public async Task<List<DraftByYearDto>> GetDraft(int year)
        {
            string urlSegment = $"draft/{year}";
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            var nhlDraftDto = await _NhlDraftMappingService.MapDraftByYear(response);

            return nhlDraftDto;
        }

        public async Task<List<DraftByYearDto>> GetDraftByTeam(int year, string teamName)
        {
            string urlSegment = $"draft/{year}";
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            var nhlDraftDto = await _NhlDraftTeamMappingService.MapDraftByTeam(response, teamName);

            return nhlDraftDto;
        }

    }
}