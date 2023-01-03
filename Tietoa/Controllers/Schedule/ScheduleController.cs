using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.GetRequest;
using Tietoa.Domain.Models.Schedule;
using Tietoa.Domain.Models.Schedule.JsonClasses;

namespace Tietoa.Controllers.Schedule
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IGetRequest _GetRequest;

        public ScheduleController(ILogger<ScheduleController> logger, IGetRequest getRequest)
        {
            _logger = logger;
            _GetRequest = getRequest;   
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = $"https://statsapi.web.nhl.com/api/v1/schedule";

            var response = await _GetRequest.DownloadResponse(url);
            var root = JsonConvert.DeserializeObject<Root>(response);

            if (root?.dates == null)
                return NotFound();

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
            return Ok(schedulesDto);
        }
    }
}
