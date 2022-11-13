﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.GetRequest;
using Tietoa.Domain.Models.Schedule;
using Tietoa.Domain.Models.Schedule.JsonClasses;

namespace Tietoa.Controllers.Schedule
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(ILogger<ScheduleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetRequest response = new GetRequest();
            var url = $"https://statsapi.web.nhl.com/api/v1/schedule";
            var root = JsonConvert.DeserializeObject<Root>(response.DownloadResponse(url).Result);

            List<ScheduleDto> schedules = new List<ScheduleDto>();
            foreach (var d in root.dates)
            {
                foreach (var g in d.games) 
                {
                    schedules.Add(new ScheduleDto
                    {
                        Date = g.gameDate,
                        AwayTeam = g.teams.away.team.name,
                        HomeTeam = g.teams.home.team.name
                    });
                }
            }
            return Ok(schedules);
        }
    }
}
