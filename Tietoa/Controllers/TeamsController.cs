using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tietoa.Models.Teams.JsonClasses;

namespace Tietoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private static HttpClient _httpClient = new HttpClient();
        
        [HttpGet]
        public async Task<Root> Index()
        {

            var url = $"https://statsapi.web.nhl.com/api/v1/teams";
            var response = await _httpClient.GetAsync(url);

            var responseString = await response.Content.ReadAsStringAsync();

            var root = JsonConvert.DeserializeObject<Root>(responseString);

            //root.teams.Count
            foreach (var t in root.teams) 
            { 
                
            
            }


            return root;
     
        }
    }
}
