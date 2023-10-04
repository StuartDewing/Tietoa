using Microsoft.AspNetCore.Mvc;
using Services.NHL.Interface;
using System.Net.Security;
using Tietoa.Domain;

namespace Tietoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DraftController : ControllerBase
    {
        private readonly ILogger<DraftController> _logger;
        private readonly INhlDraftService _nhlDraftService;
        

        public DraftController(ILogger<DraftController> logger, INhlDraftService nhlDraftService)
        {
            _logger = logger;
            _nhlDraftService = nhlDraftService;
        }

        [HttpGet]
        [Route("Year")]
        public async Task<IActionResult> DraftByYear(int year)
        {
            if (year <= NhlConstants.FirstDraftYear)
                return BadRequest($"{ValidationMessages.BadRequestDraftYear} {NhlConstants.FirstDraftYear}");

            var draftByYearsDto = await _nhlDraftService.DraftByYearRequest(year);

            if (draftByYearsDto.Count() <= 0)
                return NotFound();

            return Ok(draftByYearsDto);
        }

        [HttpGet]
        [Route("YearTeam")]
        public async Task<IActionResult> DraftByYearTeam(int year, string teamName)
        {
            if (year <= NhlConstants.FirstDraftYear)
                return BadRequest($"{ValidationMessages.BadRequestDraftYear} {NhlConstants.FirstDraftYear}");

            var draftByYearTeamsDto = await _nhlDraftService.DraftByTeamRequest(year, teamName);

            if (draftByYearTeamsDto.Count() <= 0)
                return NotFound();

            return Ok(draftByYearTeamsDto);
        }
    }
}