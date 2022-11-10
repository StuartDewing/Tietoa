using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tietoa.Models.Divisions;
using Tietoa.Models.Divisions.JsonClasses;
namespace Tietoa.Controllers.Divisions


{
    [ApiController]
    [Route("[controller]")]
    public class DivisionController : ControllerBase
    {
        private readonly ILogger<DivisionController> _logger;
        private static HttpClient _httpClient = new HttpClient();

        public DivisionController(ILogger<DivisionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = $"https://statsapi.web.nhl.com/api/v1/divisions";
            var response = await _httpClient.GetAsync(url);
            var ResponseJson = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<Root>(ResponseJson);

            List<DivisionsDto> divisions = new List<DivisionsDto>();
            foreach (var d in root.divisions)
            {
                if (d.active == true) 
                {
                    divisions.Add(new DivisionsDto
                    {
                        Id = d.id,
                        Name = d.name,
                        Conference = d.conference.name
                    });
                }   
            }
            return Ok(divisions);
        }
    }
}
