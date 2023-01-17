using Newtonsoft.Json;
using Services.NHL.Interface;
using Tietoa.Domain.Models.Player;
using Tietoa.Domain.Models.Player.JsonClasses;

namespace Services.NHL

{
    public class NhlPlayerService : INhlPlayerService
    {
        private readonly INhlRequest _NhlRequest;

        private async Task<string> nhlPlayerRequest(int playerId)
        {
            string urlSegment = $"people/{playerId}";
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            return response;
        }

        public NhlPlayerService(INhlRequest nhlRequest)
        {
            _NhlRequest = nhlRequest;
        }

        public async Task<List<PlayerDto>> PlayerRequest(int playerId)
        {
            var response = await nhlPlayerRequest(playerId);
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<PlayerDto> playerDto = new List<PlayerDto>();
            {
                playerDto.Add(new PlayerDto
                {
                    FirstName = root.people[0].firstName,
                    LastName = root.people[0].lastName,
                    Team = root.people[0].currentTeam.name,
                    Position = root.people[0].primaryPosition.name,
                    PlayerNumber = root.people[0].primaryNumber
                });
            }
            return playerDto;
        }
    }
}