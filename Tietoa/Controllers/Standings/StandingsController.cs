//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Services.NHL.NhlRequest;
//using Tietoa.Domain.Models.Standings;
//using Tietoa.Domain.Models.Standings.JsonClasses;

//namespace Tietoa.Controllers.Standings
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class StandingsController : ControllerBase
//    {
//        private readonly ILogger<StandingsController> _logger;
//        private readonly INhlRequest _NhlRequest;

//        public StandingsController(ILogger<StandingsController> logger, INhlRequest nhlRequest)
//        {
//            _logger = logger;
//            _NhlRequest = nhlRequest;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            var url = $"https://statsapi.web.nhl.com/api/v1/standings";
//            var response = await _NhlRequest.NHLGetResponse(url);
//            var root = JsonConvert.DeserializeObject<Root>(response);

//            if (root?.records == null)
//                return NotFound();

//            List<StandingsDto> standingsDto = new List<StandingsDto>();
//            foreach (var records in root.records) 
//            {
//                foreach (var teamRecords in records.teamRecords) 
//                {
//                    standingsDto.Add(new StandingsDto
//                    {
//                        Name = teamRecords.team.name,
//                        Wins = teamRecords.leagueRecord.wins,
//                        Losses = teamRecords.leagueRecord.losses,
//                        OT = teamRecords.leagueRecord.ot,
//                        Points = teamRecords.points,
//                        Goals = teamRecords.goalsScored,
//                        GoalsAgainst = teamRecords.goalsAgainst
//                    });
//                }
//            }
//            return Ok(standingsDto);
//        }
//    }

//}
