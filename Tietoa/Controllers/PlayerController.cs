using Tietoa.Models.Player;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using static Tietoa.Models.Player.PlayerReponse;
using static Tietoa.Models.Player.PlayerDto;

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
        public async Task<PlayerDto> Get()
        {

            var URL = $"https://statsapi.web.nhl.com/api/v1/people/8478007"; //ID8478007 = Elvis Merzlikins
            var response = await _httpClient.GetAsync(URL);

            var responseString = await response.Content.ReadAsStringAsync();

            //PlayerReponse playerResponse = JsonConvert.DeserializeObject<PlayerReponse>(responseString);
            PlayerResponse myDeserializedClass = JsonConvert.DeserializeObject<PlayerResponse>(responseString);
            PlayerDto playerDto = new PlayerDto
            {
                FirstName = myDeserializedClass.[0].Person.firstName
       
            };
            return playerDto;
        }

    }
}
