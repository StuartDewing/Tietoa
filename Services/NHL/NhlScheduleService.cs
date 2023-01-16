using Newtonsoft.Json;
using Services.NHL.Interface;
using Tietoa.Domain.Models.Schedule;
using Tietoa.Domain.Models.Schedule.JsonClasses;

namespace Services.NHL

{
    public class NhlScheduleService : INhlScheduleService
    {
        private readonly INhlRequest _NhlRequest;
        private string urlSegment = $"schedule";

        public NhlScheduleService(INhlRequest nhlRequest)
        {
            _NhlRequest = nhlRequest;
        }

        public async Task<List<ScheduleDto>> ScheduleRequest()
        {
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            var root = JsonConvert.DeserializeObject<Root>(response);
            List<ScheduleDto> schedulesDto = new List<ScheduleDto>();
            foreach (var dates in root.dates)
            {
                foreach (var games in dates.games)
                {
                    schedulesDto.Add(new ScheduleDto
                    {
                        Date = games.gameDate,
                        AwayTeam = games.teams.away.team.name,
                        HomeTeam = games.teams.home.team.name
                    });
                }
            }
            return schedulesDto;
        }
    }
}