using Newtonsoft.Json;
using Services.NHL.Interface;
using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Draft.JsonClasses;

namespace Services.NHL

{
    public class NhlDraftService : INhlDraftService
    {
        private readonly INhlRequest _NhlRequest;

        private async Task<string> nhlDraftRequest(int year)
        {
            string urlSegment = $"draft/{year}";
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            return response;
        }

        public NhlDraftService(INhlRequest nhlRequest)
        {
            _NhlRequest = nhlRequest;
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