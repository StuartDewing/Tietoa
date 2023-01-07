

using Newtonsoft.Json;
using Services.NHL.NhlRequest;
using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Draft.JsonClasses;

namespace Services.NHL
{
    public class NhlDraftService : INhlDraftService
    {
        private readonly INhlRequest _NhlRequest;

        public NhlDraftService(INhlRequest nhlRequest)
        {
            _NhlRequest = nhlRequest;
        }

        public async Task<List<DraftByYearDto>> GetDraftByYear(int year)
        {
            //build url
            string urlSegment = $"draft/{year}"; 

         //Call nhl request service

            var response = await _NhlRequest.NhlGetResponse(urlSegment);

            //map to responsedto

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