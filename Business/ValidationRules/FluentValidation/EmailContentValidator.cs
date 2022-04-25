using Entities;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EmailContentValidator : AbstractValidator<EmailContent>
    {
        public EmailContentValidator()
        {
            RuleFor(c => c.Subject).NotEmpty().MaximumLength(150);
            RuleFor(c => c.Message).NotEmpty().MaximumLength(500);
            RuleFor(c => c.To).NotEmpty().EmailAddress();
        }
    }
}
