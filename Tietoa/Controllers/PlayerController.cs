using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tietoa.Models.Player;
using Tietoa.Models.Player.JsonClasses;
using Services.Player.Class1
namespace Tietoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private static HttpClient _httpClient = new HttpClient();

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id) //8478007 = Elvis Merzlikins
        {
            if (id == 0)
                return BadRequest("Player id missing");

            //var player = _playerService.get(playerId);
            //if (player == null)
            //    return NotFound();

            //return Ok(player);

            PlayerResponse playerResponse = await NewMethod(id);

            if (playerResponse.people[0].firstName == null)
                return BadRequest("Invalid player id");

            PlayerDto playerDto = new PlayerDto
            {
                FirstName = playerResponse.people[0].firstName,
                LastName = playerResponse.people[0].lastName,
                Team = playerResponse.people[0].currentTeam.name,
                Position = playerResponse.people[0].primaryPosition.name,
                PlayerNumber = playerResponse.people[0].primaryNumber
            };
            return Ok(playerDto);
        }


    }
}
