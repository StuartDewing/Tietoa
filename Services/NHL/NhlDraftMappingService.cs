using Newtonsoft.Json;
using Services.NHL.Interface;
using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Draft.JsonClasses;

namespace Services.NHL
{
    public class NhlDraftMappingService : INhlDraftMappingService
    {
       
        public async Task<List<DraftByYearDto>> MapDraftByYear(string response)
        {
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
    }
}