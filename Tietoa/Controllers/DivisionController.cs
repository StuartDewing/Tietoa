using Microsoft.AspNetCore.Mvc;
using Services.NHL.Interface;

namespace Tietoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisionController : ControllerBase
    {
        private readonly ILogger<DivisionController> _logger;
        private readonly INhlDivisionsService _nhlDivisionsService;

        public DivisionController(ILogger<DivisionController> logger, INhlDivisionsService divisionsService)
        {
            _logger = logger;
            _nhlDivisionsService = divisionsService;
        }

        [HttpGet]
        [Route("ActiveDivisions")]
        public async Task<IActionResult> ActiveDivisions()
        {
            var divisionsDto = await _nhlDivisionsService.DivisionsRequest();

            return Ok(divisionsDto);
        }
    }
}
