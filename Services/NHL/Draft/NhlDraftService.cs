using Newtonsoft.Json;
using Services.NHL.Interface;
using Services.NHL.Interface.Draft;
using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Draft.JsonClasses;

namespace Services.NHL.Draft

{
    public class NhlDraftService : INhlDraftService
    {
        private readonly INhlRequest _NhlRequest;
        private readonly INhlDraftRequestService _NhlDraftRequestService;
        private readonly INhlDraftMappingService _NhlDraftMappingService;
        private readonly INhlDraftTeamMappingService _NhlDraftTeamMappingService;

        private async Task<string> nhlDraftRequest(int year)
        {
            string urlSegment = $"draft/{year}";
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            return response;
        }

        public NhlDraftService(INhlRequest nhlRequest, INhlDraftRequestService nhlDraftRequestService, INhlDraftMappingService nhlDraftMappingService, INhlDraftTeamMappingService nhlDraftTeamMappingService)
        {
            _NhlRequest = nhlRequest;
            _NhlDraftRequestService = nhlDraftRequestService;
            _NhlDraftMappingService = nhlDraftMappingService;
            _NhlDraftTeamMappingService = nhlDraftTeamMappingService;
        }

        public async Task<List<DraftByYearDto>> DraftByYearRequest(int year)
        {
            var response = await nhlDraftRequest(year);
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<DraftByYearDto> draftByYearsDto = new List<DraftByYearDto>();

            if (root == null)
                return draftByYearsDto;

            foreach (var drafts in root.drafts)
            {
                foreach (var rounds in drafts.rounds)
                {
                    foreach (var picks in rounds.picks)
                    {
                        draftByYearsDto.Add(new DraftByYearDto
                        {
                            Round = picks.round,
                            Pick = picks.pickOverall,
                            Team = picks.team.name,
                            FullName = picks.prospect.fullName
                        });
                    }
                }
            }
            return draftByYearsDto;
        }

        public async Task<List<DraftByYearDto>> DraftByTeamRequest(int year, string teamName)
        {
            var response = await nhlDraftRequest(year);
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<DraftByYearDto> draftByNameDto = new List<DraftByYearDto>();

            if (root == null)
                return draftByNameDto;

            foreach (var drafts in root.drafts)
            {
                foreach (var rounds in drafts.rounds)
                {
                    foreach (var picks in rounds.picks.Where(t => t.team.name == teamName))
                    {
                        draftByNameDto.Add(new DraftByYearDto
                        {
                            Round = picks.round,
                            Pick = picks.pickOverall,
                            Team = picks.team.name,
                            FullName = picks.prospect.fullName
                        });
                    }
                }
            }
            return draftByNameDto;
        }
    }
}