using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.GetRequest;
using Tietoa.Domain.Models.Standings;
using Tietoa.Domain.Models.Standings.JsonClasses;

namespace Tietoa.Controllers.Standings
{
    [ApiController]
    [Route("[controller]")]
    public class StandingsTeamController : ControllerBase
    {
        private readonly ILogger<StandingsTeamController> _logger;

        public StandingsTeamController(ILogger<StandingsTeamController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string team)
        {
            GetRequest response = new GetRequest();
            var url = $"https://statsapi.web.nhl.com/api/v1/standings";
            var root = JsonConvert.DeserializeObject<Root>(response.DownloadResponse(url).Result);

            List<StandingsDto> standings = new List<StandingsDto>();
            foreach (var r in root.records) 
            {
                foreach (var tr in r.teamRecords.Where(t => t.team.name == team)) 
                {
                    standings.Add(new StandingsDto
                    {
                        Name = tr.team.name,
                        Wins = tr.leagueRecord.wins,
                        Losses = tr.leagueRecord.losses,
                        OT = tr.leagueRecord.ot,
                        Points = tr.points,
                        Goals = tr.goalsScored,
                        GoalsAgainst = tr.goalsAgainst
                    });
                }
            }
            return Ok(standings);
        }
    }

}
