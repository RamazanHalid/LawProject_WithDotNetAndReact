using Entities.DTOs.CustomerDtos;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerAddDtoValidator : AbstractValidator<CustomerAddDto>
    {
        public CustomerAddDtoValidator()
        {
            RuleFor(c => c.CustomerName).MinimumLength(2);
            RuleFor(c => c.CityId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.BillAddress).MinimumLength(15);
            RuleFor(c => c.WebSite).MinimumLength(10);
            RuleFor(c => c.PhoneNumber).Must(CheckPhoneNumber);
            RuleFor(c => c.TaxNo).MinimumLength(3);
            RuleFor(c => c.TaxOffice).MinimumLength(3);
            RuleFor(c => c.Email).EmailAddress();
        }

        public bool CheckPhoneNumber(string arg)
        {

            return Regex.IsMatch(arg, @"^((\d{11}))$", RegexOptions.IgnoreCase);

        }
    }
}
