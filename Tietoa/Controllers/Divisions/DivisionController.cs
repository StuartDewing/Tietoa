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
            var root = JsonConvert.DeserializeObject<Root>(_GetRequest.DownloadResponse(url).Result);

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
