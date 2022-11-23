using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.GetRequest;
using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Draft.JsonClasses;

namespace Tietoa.Controllers.Draft
{
    [ApiController]
    [Route("[controller]")]
    public class DraftYearController : ControllerBase
    {
        private readonly ILogger<DraftYearController> _logger;
        private readonly IGetRequest _GetRequest;

        public DraftYearController(ILogger<DraftYearController> logger, IGetRequest getRequest)
        {
            _logger = logger;
            _GetRequest = getRequest;   
        }

        [HttpGet]
        public async Task<IActionResult> Index(int year)
        {
            if (year == 0)
                return BadRequest("Draft year missing");

            var url = $"https://statsapi.web.nhl.com/api/v1/draft/{year}";
            var root = JsonConvert.DeserializeObject<Root>(_GetRequest.DownloadResponse(url).Result);

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
