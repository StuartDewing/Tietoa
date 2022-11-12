using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Draft.JsonClasses;


namespace Tietoa.Controllers.Draft
{
    [ApiController]
    [Route("[controller]")]
    public class DraftYearController : ControllerBase
    {
        private readonly ILogger<DraftYearController> _logger;
        private static HttpClient _httpClient = new HttpClient();

        public DraftYearController(ILogger<DraftYearController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int year)
        {
            if (year == 0)
                return BadRequest("Draft year missing");

            var url = $"https://statsapi.web.nhl.com/api/v1/draft/{year}";
            var response = await _httpClient.GetAsync(url);
            var responseJson = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<Root>(responseJson);

            List<DraftByYearDto> draftByYears = new List<DraftByYearDto>();
            foreach (var d in root.drafts)
            {
                foreach (var r in d.rounds)
                {
                    foreach (var p in r.picks)
                    {
                        draftByYears.Add(new DraftByYearDto
                        {
                            Round = p.round,
                            Pick = p.pickOverall,
                            Team = p.team.name,
                            FullName = p.prospect.fullName
                        });
                    }
                }
            }
            return Ok(draftByYears);
        }
    }
}
