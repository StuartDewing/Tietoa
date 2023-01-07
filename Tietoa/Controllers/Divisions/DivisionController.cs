//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Services.NHL.NhlRequest;
//using Tietoa.Domain.Models.Divisions;
//using Tietoa.Domain.Models.Divisions.JsonClasses;

//namespace Tietoa.Controllers.Divisions
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class DivisionController : ControllerBase
//    {
//        private readonly ILogger<DivisionController> _logger;
//        private readonly INhlRequest _NhlRequest;

//        public DivisionController(ILogger<DivisionController> logger, INhlRequest nhlRequest)
//        {
//            _logger = logger;
//            _NhlRequest = nhlRequest;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {

//            var url = $"https://statsapi.web.nhl.com/api/v1/divisions";
//            var response = await _NhlRequest.NHLGetResponse(url);
//            var root = JsonConvert.DeserializeObject<Root>(response);

//            //TODO: Error handerling

//            if (root?.divisions == null)
//                return NotFound();

//            List<DivisionsDto> divisionsDto = new List<DivisionsDto>();
//            foreach (var division in root.divisions)
//            {
//                if (division.active)
//                {
//                    divisionsDto.Add(new DivisionsDto
//                    {
//                        Id = division.id,
//                        Name = division.name,
//                        Conference = division.conference.name
//                    });
//                }
//            }
//            return Ok(divisionsDto);
//        }
//    }
//}
