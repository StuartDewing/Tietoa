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
            playerId = 8484166;
            //if (playerId <= NhlConstants.FirstDraftYear)
               // return BadRequest($"{ValidationMessages.BadRequestDraftYear} {NhlConstants.FirstDraftYear}");

            var playerByIdDto = await _nhlPlayerService.PlayerRequest(playerId);

            //if (draftByYearsDto.Count() <= 0)
            //    return NotFound();

            return Ok(playerByIdDto);
        }
    }
}