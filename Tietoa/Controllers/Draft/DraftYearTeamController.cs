using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.NHL.NhlRequest;
using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Draft.JsonClasses;

namespace Tietoa.Controllers.Draft
{
    [ApiController]
    [Route("[controller]")]
    public class DraftYearTeamController : ControllerBase
    {
        private readonly ILogger<DraftYearController> _logger;
        private readonly IGetData _NhlRequest;

        public DraftYearTeamController(ILogger<DraftYearController> logger, IGetData nhlRequest)
        {
            _logger = logger;
            _NhlRequest = nhlRequest;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int year, string team)
        {
            if (year == 0 )
                return BadRequest("Draft year missing");
            if (team == null)
                return BadRequest("Team name missing");

            var url = $"https://statsapi.web.nhl.com/api/v1/draft/{year}";
            var response = await _NhlRequest.NHLGetResponse(url);
            var root = JsonConvert.DeserializeObject<Root>(response);

            if (root?.drafts == null)
                return NotFound();

            List<DraftByYearDto> draftByYearsDto = new List<DraftByYearDto>();
            foreach (var drafts in root.drafts)
            {
                foreach (var rounds in drafts.rounds)
                {
                    foreach (var picks in rounds.picks.Where(t => t.team.name == team))
                    {
                        draftByYearsDto.Add(new DraftByYearDto
                        {
                            Round = picks.round,
                            Pick = picks.pickOverall,
                            Team = picks.team.name,
                            FullName = picks.prospect.fullName
                        });
                    }
                }
            }
            return Ok(draftByYearsDto);
        }
    }
}
