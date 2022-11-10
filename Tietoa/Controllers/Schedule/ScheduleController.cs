using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tietoa.Models.Schedule;
using Tietoa.Models.Schedule.JsonClasses;


namespace Tietoa.Controllers.Schedule
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;
        private static HttpClient _httpClient = new HttpClient();

        public ScheduleController(ILogger<ScheduleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = $"https://statsapi.web.nhl.com/api/v1/schedule";
            var response = await _httpClient.GetAsync(url);
            var responseJson = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<Root>(responseJson);

            List<ScheduleDto> schedules = new List<ScheduleDto>();
            foreach (var d in root.dates)
            {
                foreach (var g in d.games) 
                {
                    schedules.Add(new ScheduleDto
                    {
                        Date = g.gameDate,
                        AwayTeam = g.teams.away.team.name,
                        HomeTeam = g.teams.home.team.name
                    });
                }
            }
            return Ok(schedules);
        }
    }
}
