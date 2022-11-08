using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tietoa.Models.Player.JsonClasses;
using Tietoa.Models.Teams;
using Tietoa.Models.Teams.JsonClasses;

namespace Tietoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private static HttpClient _httpClient = new HttpClient();
        
        [HttpGet]
        public async Task<IActionResult> Index(int Id)
        {

            var url = $"https://statsapi.web.nhl.com/api/v1/teams";
            var response = await _httpClient.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();

            var root = JsonConvert.DeserializeObject<Root>(responseString);
            List<TeamDto> teamsDto = new List<TeamDto>();

            foreach (var t in root.teams) 
            {
                teamsDto.Add(new TeamDto { Id = t.id, Name = t.name });
            }

            return Ok(teamsDto);
        }
    }
}
