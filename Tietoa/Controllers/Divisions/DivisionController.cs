using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.GetRequest;
using Tietoa.Domain.Models.Divisions;
using Tietoa.Domain.Models.Divisions.JsonClasses;

namespace Tietoa.Controllers.Divisions
{
    [ApiController]
    [Route("[controller]")]
    public class DivisionController : ControllerBase
    {
        private readonly ILogger<DivisionController> _logger;
        private readonly IGetRequest _GetRequest;

        public DivisionController(ILogger<DivisionController> logger, IGetRequest getRequest)
        {
            _logger = logger;
            _GetRequest = getRequest;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
          
            var url = $"https://statsapi.web.nhl.com/api/v1/divisions";

            //TODO: Error handerling
            var response = await _GetRequest.DownloadResponse(url);

            var root = JsonConvert.DeserializeObject<Root>(response);

            if (root?.divisions == null)
                return NotFound();  

            List<DivisionsDto> divisionsDto = new List<DivisionsDto>();
            foreach (var division in root.divisions)
            {
                if (division.active) 
                {
                    divisionsDto.Add(new DivisionsDto
                    {
                        Id = division.id,
                        Name = division.name,
                        Conference = division.conference.name
                    });
                }   
            }
            return Ok(divisionsDto);
        }
    }
}
