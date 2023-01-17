using Microsoft.AspNetCore.Mvc;
using Services.NHL.Interface;

namespace Tietoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<DivisionController> _logger;
        private readonly INhlScheduleService _nhlScheduleService;

        public ScheduleController(ILogger<DivisionController> logger, INhlScheduleService ScheduleService)
        {
            _logger = logger;
            _nhlScheduleService = ScheduleService;
        }

        [HttpGet]
        [Route("Schedule")]
        public async Task<IActionResult> ActiveSchedule()
        {
            var ScheduleDto = await _nhlScheduleService.ScheduleRequest();

            return Ok(ScheduleDto);
        }
    }
}
