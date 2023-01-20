using Newtonsoft.Json;
using Services.NHL.Interface;
using Tietoa.Domain;
using Tietoa.Domain.Models.Teams;
using Tietoa.Domain.Models.Teams.JsonClasses;

namespace Services.NHL

{
    public class NhlTeamsService : INhlTeamsService
    {
        private readonly INhlRequest _NhlRequest;
        private string urlSegment = $"{NhlConstants.Teams}";

        public NhlTeamsService(INhlRequest nhlRequest)
        {
            _NhlRequest = nhlRequest;
        }

        public async Task<List<TeamDto>> TeamsRequest()
        {
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<TeamDto> teamsDto = new List<TeamDto>();
            foreach (var teams in root.teams)
            {
                teamsDto.Add(new TeamDto
                {
                    Id = teams.id,
                    Name = teams.name
                });
            }
            return teamsDto;
        }
    }
}