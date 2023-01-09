using Services.NHL.Interface.Draft;
using Tietoa.Domain.Models.Draft;

namespace Services.NHL.Draft

{
    public class NhlDraftService : INhlDraftService
    {
        private readonly INhlDraftRequestService _NhlDraftRequestService;

        public NhlDraftService(INhlDraftRequestService nhlDraftRequestService)
        {
            _NhlDraftRequestService = nhlDraftRequestService;
        }

        public async Task<List<DraftByYearDto>> DraftByYearRequest(int year)
        {
            var nhlDraftDto = await _NhlDraftRequestService.GetDraft(year);

            return nhlDraftDto;
        }

        public async Task<List<DraftByYearDto>> DraftByTeamRequest(int year, string teamName)
        {
            var nhlDraftDto = await _NhlDraftRequestService.GetDraftByTeam(year, teamName);

            return nhlDraftDto;
        }
    }
}