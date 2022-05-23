using Entities.DTOs.LicenceDtos;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class LicenceAddDtoValidator : AbstractValidator<LicenceAddDto>
    {
        public LicenceAddDtoValidator()
        {
            RuleFor(c => c.PersonTypeId).GreaterThan(0);
            RuleFor(c => c.CityId).GreaterThan(0);
            RuleFor(c => c.BillAddress).NotEmpty().MaximumLength(200);
            RuleFor(c => c.WebSite).NotEmpty().MaximumLength(50);
            //RuleFor(c => c.PhoneNumber).Must(CheckPhoneNumber).WithMessage("Number must be 11 digits!");
            RuleFor(c => c.ProfilName).NotEmpty().MaximumLength(50);
            RuleFor(c => c.TaxNo).NotEmpty().MaximumLength(10);
            RuleFor(c => c.TaxOffice).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
        }

        public bool CheckPhoneNumber(string arg)
        {

            return Regex.IsMatch(arg, @"^((\d{10}))$", RegexOptions.IgnoreCase);

        }
    }
}
