using Microsoft.AspNetCore.Mvc;
using Services.NHL.Interface;

namespace Tietoa.Controllers.Draft
{
    [ApiController]
    [Route("[controller]")]
    public class DraftYearController : ControllerBase
    {
        private readonly ILogger<DraftYearController> _logger;
        private readonly INhlDraftService _nhlDraftService;

        public DraftYearController(ILogger<DraftYearController> logger, INhlDraftService nhlDraftService)
        {
            _logger = logger;
            _nhlDraftService = nhlDraftService;
        }

        [HttpGet]
        [Route("DraftByYear")]
        public async Task<IActionResult> DraftByYear(int year)
        {
            if (year <= 1963)
                return BadRequest("Draft year before the first draft of 1963 ");

            var draftByYearsDto = await _nhlDraftService.DraftByYearRequest(year);

            if (draftByYearsDto.Count() <= 0)
                return NotFound();

            return Ok(draftByYearsDto);
        }

        [HttpGet]
        [Route("DraftByYearTeam")]
        public async Task<IActionResult> DraftByYearTeam(int year, string teamName)
        {
            if (year <= 1963)
                return BadRequest("Draft year before the first draft of 1963 ");

            var draftByYearTeamsDto = await _nhlDraftService.DraftByTeamRequest(year, teamName);

            if (draftByYearTeamsDto.Count() <= 0)
                return NotFound();

            return Ok(draftByYearTeamsDto);
        }

    }
}
