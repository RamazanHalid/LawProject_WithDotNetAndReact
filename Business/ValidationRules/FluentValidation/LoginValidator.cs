using Business.Constants;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(l => l.CellPhone).Must(IsCellPhoneCorrectForm).WithMessage(Messages.ToString(Messages.CellPhoneValidation));
            RuleFor(l => l.Password).MinimumLength(1).WithMessage(Messages.ToString(Messages.PasswordValidation));


        }

        private bool IsCellPhoneCorrectForm(string arg)
        {
            return  arg.StartsWith("5") || arg.Length == 10;
        }

    }

}
