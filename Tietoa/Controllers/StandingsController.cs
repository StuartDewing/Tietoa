using Microsoft.AspNetCore.Mvc;
using Services.NHL;
using Services.NHL.Interface;

namespace Tietoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StandingsController : ControllerBase
    {
        private readonly ILogger<StandingsController> _logger;
        private readonly INhlStandingsService _nhlStandingsService;

        public StandingsController(ILogger<StandingsController> logger, INhlStandingsService nhlStandingsService)
        {
            _logger = logger;
            _nhlStandingsService = nhlStandingsService;
        }

        [HttpGet]
        [Route("League")]
        public async Task<IActionResult> StandingsLeague()
        {
            var standingsDto = await _nhlStandingsService.StandingsRequest();

            return Ok(standingsDto);
        }

        [HttpGet]
        [Route("Team")]
        public async Task<IActionResult> StandingsTeam(string team)
        {
            var standingsDto = await _nhlStandingsService.StandingsTeamRequest(team);

            return Ok(standingsDto);
        }
    }

}
