using Entities.DTOs.CustomerDtos;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerAddDtoValidator : AbstractValidator<CustomerAddDto>
    {
        public CustomerAddDtoValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty().MaximumLength(200);
            RuleFor(c => c.CityId).NotEmpty().GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.BillAddress).NotEmpty().MaximumLength(250);
            RuleFor(c => c.WebSite).NotEmpty().MaximumLength(100);
            RuleFor(c => c.PhoneNumber).Must(CheckPhoneNumber);
            RuleFor(c => c.TaxNo).NotEmpty().MaximumLength(20);
            RuleFor(c => c.TaxOffice).NotEmpty().MaximumLength(60);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
        }

        public bool CheckPhoneNumber(string arg)
        {

            return Regex.IsMatch(arg, @"^((\d{10}))$", RegexOptions.IgnoreCase);

        }
    }
}
