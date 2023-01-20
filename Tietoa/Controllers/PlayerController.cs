using Microsoft.AspNetCore.Mvc;
using Services.NHL.Interface;
using Tietoa.Domain;

namespace Tietoa.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly INhlPlayerService _NhlPlayerService;

        public PlayerController(ILogger<PlayerController> logger, INhlPlayerService nhlPlayerService)
        {
            _logger = logger;
            _NhlPlayerService = nhlPlayerService;
        }

        [HttpGet]
        [Route("PlayerId")]
        public async Task<IActionResult> Get(int playerId) //8478007 = Elvis Merzlikins
        {
            if (playerId == 0)
                return BadRequest($"{ValidationMessages.BadRequestPlayerIdMissing}");

            var playerDto = await _NhlPlayerService.PlayerRequest(playerId);

            return Ok(playerDto);
        }
    }
}
