using FluentValidation;
using Tietoa.Domain.Models.Player;

namespace Services.NHL.Player.Validation
{
    public class PlayerValidator : AbstractValidator<PlayerRequestModel>
    {
        public PlayerValidator() 
        { 
            RuleFor(x => x.PlayerId).NotNull().NotEmpty();
        }
    }
}
