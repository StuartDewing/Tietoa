using Microsoft.AspNetCore.Mvc;
using Services.NHL.Interface;

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
        public async Task<IActionResult> DraftByYear(int year)
        {
            if (year <= 1963)//TODO
                return BadRequest("Draft year before the first draft of 1963 ");

            var draftByYearsDto = await _nhlDraftService.GetDraftByYear(year);
            
            if (draftByYearsDto.Count() <= 0)
                return NotFound();
           
            return Ok(draftByYearsDto);
        }

        //[HttpGet]
        //public async Task<IActionResult> DraftByYearTeam(int year, string team)
        //{
        //    if (year <= 1963)//TODO
        //        return BadRequest("Draft year before the first draft of 1963 ");

        //    var draftByYearsDto = await _nhlDraftService.GetDraftByYear(year);

        //    if (draftByYearsDto.Count() <= 0)
        //        return NotFound();

        //    return Ok(draftByYearsDto);
        //}

    }
}
