using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Services.NHL.Player;
using Services.NHL.Player.Interface;
using Tietoa.Domain.Models.Player;

namespace Tietoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly INhlPlayerService _nhlPlayerService;
        private IValidator<PlayerRequestModel> _validator;

        
        public PlayerController(
            ILogger<PlayerController> logger, 
            INhlPlayerService nhlPlayerService,
            IValidator<PlayerRequestModel> validator )
        {
            _logger = logger;
            _nhlPlayerService = nhlPlayerService;
            _validator = validator;
        }

        [HttpGet]
        [Route("Player")] //playerId = 8484166;
        public async Task<IActionResult> PlayerById([FromQuery]PlayerRequestModel request)
        {
            ValidationResult result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                var errorMessages = new List<string>();

                for (int i = 0; i < result.Errors.Count; i++)
                {
                    errorMessages.Add(result.Errors[i].ErrorMessage);                
                }

               return BadRequest(errorMessages);
            }

            var playerByIdDto = await _nhlPlayerService.PlayerRequest(request);

            return Ok(playerByIdDto);
        }
    }
}