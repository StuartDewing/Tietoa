using Microsoft.AspNetCore.Mvc;
using Services.NHL.Interface;

namespace Tietoa.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly INhlTeamsService _nhlTeamsService;

        public TeamsController(ILogger<TeamsController> logger, INhlTeamsService TeamsService)
        {
            _logger = logger;
            _nhlTeamsService = TeamsService;
        }

        [HttpGet]
        [Route("ActiveTeams")]
        public async Task<IActionResult> ActiveTeams()
        {
            var TeamsDto = await _nhlTeamsService.TeamsRequest();

            return Ok(TeamsDto);
        }
    }
}
