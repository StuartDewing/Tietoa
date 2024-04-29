using FluentValidation;

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
