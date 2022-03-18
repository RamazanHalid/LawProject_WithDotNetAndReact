using Entities.DTOs.UserDtos;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
          
            RuleFor(l => l.Password).MinimumLength(8);
            RuleFor(l => l.CellPhone).Must(CheckCellPhoneFormat).WithMessage("Format of cell phone must be like 5xxxxxxxxx");


        }

        private bool CheckCellPhoneFormat(string arg)
        {
            return Regex.IsMatch(arg, @"^(5(\d{9}))$", RegexOptions.IgnoreCase);
        }

    }

}
