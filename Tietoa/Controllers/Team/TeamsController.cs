using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.GetRequest;
using Tietoa.Domain.Models.Teams;
using Tietoa.Domain.Models.Teams.JsonClasses;

namespace Tietoa.Controllers.Team
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly IGetRequest _GetRequest;

        public TeamsController(ILogger<TeamsController> logger, IGetRequest  getRequest   ) 
        {
            _logger = logger;
            _GetRequest = getRequest;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var url = $"https://statsapi.web.nhl.com/api/v1/teams";
           
            var response = await _GetRequest.DownloadResponse(url);
            var root = JsonConvert.DeserializeObject<Root>(response);

            if (root?.teams == null)
                return NotFound();

            List<TeamDto> teamsDto = new List<TeamDto>();
            foreach (var teams in root.teams)
            {
                teamsDto.Add(new TeamDto 
                { 
                    Id = teams.id, 
                    Name = teams.name 
                });
            }
            return Ok(teamsDto);
        }
    }
}
