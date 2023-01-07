using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.NHL.Interface;
using Services.NHL.NhlRequest;
using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Draft.JsonClasses;

namespace Tietoa.Controllers.Draft
{
    [ApiController]
    [Route("[controller]")]
    public class DraftYearController : ControllerBase
    {
        private readonly ILogger<DraftYearController> _logger;
        private readonly INhlDraftService _nhlDraftService;

        public DraftYearController(ILogger<DraftYearController> logger, INhlDraftService nhlDraftService)
        {
            _logger = logger;
            _nhlDraftService = nhlDraftService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int year)
        {
            if (year <= 1963)//TODO
                return BadRequest("Draft year before the first draft of 1963 ");

            var draftByYearsDto = await _nhlDraftService.GetDraftByYear(year);
            
            if (draftByYearsDto.Count() <= 0)
                return NotFound();
           
            return Ok(draftByYearsDto);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetByYearTeam(int year, string team)
        //{
        //    if (year == 0)
        //        return BadRequest("Draft year missing");
        //    if (string.IsNullOrWhiteSpace(team))
        //        return BadRequest("Team name missing");

        //    var year = $"https://statsapi.web.nhl.com/api/v1/draft/{year}";
        //    var response = await _NhlRequest.NHLGetResponse(url);
        //    var root = JsonConvert.DeserializeObject<Root>(response);

        //    if (root?.drafts == null)
        //        return NotFound();

        //    List<DraftByYearDto> draftByYearsDto = new List<DraftByYearDto>();
        //    foreach (var drafts in root.drafts)
        //    {
        //        foreach (var rounds in drafts.rounds)
        //        {
        //            foreach (var picks in rounds.picks.Where(t => t.team.name == team))
        //            {
        //                draftByYearsDto.Add(new DraftByYearDto
        //                {
        //                    Round = picks.round,
        //                    Pick = picks.pickOverall,
        //                    Team = picks.team.name,
        //                    FullName = picks.prospect.fullName
        //                });
        //            }
        //        }
        //    }
        //    return Ok(draftByYearsDto);
        //}

    }
}
