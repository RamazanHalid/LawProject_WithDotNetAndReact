using Business.Constants;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForLoginValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForLoginValidator()
        {
             
            RuleFor(l => l.Password).MinimumLength(1);


        }

       

    }

}
