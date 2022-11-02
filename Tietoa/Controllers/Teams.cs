//using Tietoa.Models.Teams;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using System.Text.Json;
//using static Tietoa.Models.Teams.TeamsResponse;
//using  static Tietoa.Models.Teams.TeamsDto;

//namespace Tietoa.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]                                           // Understanding Gap
//    public class TeamsController : ControllerBase                     //Base = Without view support
//    {
//        private readonly ILogger<TeamsController> _logger;
//        private static HttpClient _httpClient = new HttpClient();

//        public TeamsController(ILogger<TeamsController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet]
//        public async Task<TeamsDto> Get()
//        {

//            var URL = $"https://statsapi.web.nhl.com/api/v1/teams/";
//            var response = await _httpClient.GetAsync(URL);
            
//            var responseString = await response.Content.ReadAsStringAsync();

//            TeamsResponse teamsResponse =  ;
//            TeamsDto teamsDto = new TeamsDto
//            {
//                Name = responseString.teams[0].name,
//                Id = responseString.teams[0].Team

//            };

//            return teamsDto;
//        }
//    }
//}
