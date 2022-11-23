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
           // GetRequest response = new GetRequest();
            var url = $"https://statsapi.web.nhl.com/api/v1/teams";
            var root = JsonConvert.DeserializeObject<Root>(_GetRequest.DownloadResponse(url).Result);

            List<TeamDto> teamsDto = new List<TeamDto>();
            foreach (var t in root.teams)
            {
                teamsDto.Add(new TeamDto 
                { 
                    Id = t.id, 
                    Name = t.name 
                });
            }
            return Ok(teamsDto);
        }
    }
}
