using Entities.DTOs.UserDtos;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterValidator()
        {
            RuleFor(l => l.CityId).GreaterThan(0);
            RuleFor(l => l.LastName).MinimumLength(2);
            RuleFor(l => l.FirstName).MinimumLength(2);
            RuleFor(l => l.Title).MinimumLength(2);
            RuleFor(l => l.CellPhone).Must(CheckCellPhoneFormat);
            RuleFor(l => l.Password).MinimumLength(8);
        }
        private bool CheckCellPhoneFormat(string arg)
        {
            return Regex.IsMatch(arg, @"^(5(\d{9}))$", RegexOptions.IgnoreCase);
        }
    }

}
