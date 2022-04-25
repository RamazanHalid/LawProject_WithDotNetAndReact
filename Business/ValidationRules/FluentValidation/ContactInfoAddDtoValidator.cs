using Entities.Concrete;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactInfoAddDtoValidator : AbstractValidator<ContactInformation>
    {
        public ContactInfoAddDtoValidator()
        {
            RuleFor(c => c.Id).Equals(0);
            RuleFor(c => c.Fullname).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Title).NotEmpty().MaximumLength(20);
            RuleFor(c => c.Message).NotEmpty().MaximumLength(250);
            RuleFor(c => c.CellPhone).Must(CheckCellPhoneFormat).WithMessage("Format must be like 5xxxxxxxxx");



        }
        private bool CheckCellPhoneFormat(string arg)
        {
            return Regex.IsMatch(arg, @"^(5(\d{9}))$", RegexOptions.IgnoreCase);
        }
    }
}
