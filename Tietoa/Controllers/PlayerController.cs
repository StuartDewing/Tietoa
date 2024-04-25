using Microsoft.AspNetCore.Mvc;
using Services.NHL.Interface;
using Services.NHL.Player.Interface;
using System.Net.Security;
using Tietoa.Domain;

namespace Tietoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly INhlPlayerService _nhlPlayerService;
        

        public PlayerController(ILogger<PlayerController> logger, INhlPlayerService nhlPlayerService)
        {
            _logger = logger;
            _nhlPlayerService = nhlPlayerService;
        }

        [HttpGet]
        [Route("Player")]
        public async Task<IActionResult> PlayerById(int playerId)
        {
            //if (playerId <= NhlConstants.FirstDraftYear)
            //    return BadRequest($"{ValidationMessages.BadRequestDraftYear} {NhlConstants.FirstDraftYear}");

            var playerByIdDto = await _nhlPlayerService.PlayerRequest(playerId);

            //if (draftByYearsDto.Count() <= 0)
            //    return NotFound();

            return Ok(playerByIdDto);
        }

        //[HttpGet]
        //[Route("YearTeam")]
        //public async Task<IActionResult> DraftByYearTeam(int year, string teamName)
        //{
        //    if (year <= NhlConstants.FirstDraftYear)
        //        return BadRequest($"{ValidationMessages.BadRequestDraftYear} {NhlConstants.FirstDraftYear}");

        //    var draftByYearTeamsDto = await _nhlPlayerService.DraftByTeamRequest(year, teamName);

        //    if (draftByYearTeamsDto.Count() <= 0)
        //        return NotFound();

        //    return Ok(draftByYearTeamsDto);
        //}
    }
}