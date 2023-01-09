using Newtonsoft.Json;
using Services.NHL.Interface.Draft;
using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Draft.JsonClasses;

namespace Services.NHL.Draft
{
    public class NhlDraftTeamMappingService : INhlDraftTeamMappingService
    {

        public async Task<List<DraftByYearDto>> MapDraftByTeam(string response, string teamName)
        {
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