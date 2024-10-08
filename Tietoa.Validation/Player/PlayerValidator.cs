﻿using FluentValidation;
using Tietoa.Domain.Models.Player;

namespace Tietoa.Validation.Player
{
    public class PlayerValidator : AbstractValidator<PlayerRequestModel>
    {
        public PlayerValidator() 
        { 
            RuleFor(x => x.PlayerId).NotNull().NotEmpty();
        }
    }
}
