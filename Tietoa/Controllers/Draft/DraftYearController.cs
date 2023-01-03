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

            var response = await _GetRequest.DownloadResponse(url);
            var root = JsonConvert.DeserializeObject<Root>(response);

            //if (root?.drafts == null)
            //    return NotFound();

            List<DraftByYearDto> draftByYearsDto = new List<DraftByYearDto>();
            foreach (var drafts in root.drafts)
            {
                foreach (var rounds in drafts.rounds)
                {
                    foreach (var picks in rounds.picks)
                    {
                        draftByYearsDto.Add(new DraftByYearDto
                        {
                            Round = picks.round,
                            Pick = picks.pickOverall,
                            Team = picks.team.name,
                            FullName = picks.prospect.fullName
                        });
                    }
                }
            }
            return Ok(draftByYearsDto);
        }
    }
}
