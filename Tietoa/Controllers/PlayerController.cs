using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tietoa.Models.Player;
using Tietoa.Models.Player.JsonClasses;

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
        //public async Task<IActionResult> Get(int id)
        public async Task<PlayerDto> Get(int id)

        {
            //if (id == 0)
            //    return BadRequest("Player id missing");

            //var player = _playerService.get(playerId);
            //if (player == null)
            //    return NotFound();

            //return Ok(player);

            // refactor to be a service (A)
            var playerId = 8478007;  //ID8478007 = Elvis Merzlikins
            var url = $"https://statsapi.web.nhl.com/api/v1/people/{playerId}";
            var response = await _httpClient.GetAsync(url);

            var responseString = await response.Content.ReadAsStringAsync();

            PlayerResponse playerResponse = JsonConvert.DeserializeObject<PlayerResponse>(responseString);

            // refactor to be a service (B)
            PlayerDto playerDto = new PlayerDto
            {
                FirstName = playerResponse.people[0].firstName,
                LastName = playerResponse.people[0].lastName,
                Team = playerResponse.people[0].currentTeam.name,
                Position = playerResponse.people[0].primaryPosition.name,
                PlayerNumber = playerResponse.people[0].primaryNumber
            };
            return playerDto;
        }

    }
}
