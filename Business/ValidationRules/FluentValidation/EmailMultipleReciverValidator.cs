using Entities;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EmailMultipleReciverValidator : AbstractValidator<EmailMultipleReciver>
    {
        public EmailMultipleReciverValidator()
        {

            RuleFor(c => c.Message).NotEmpty().MaximumLength(250);
            RuleFor(c => c.Subject).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Tos).NotEmpty().ForEach(e => e.EmailAddress());

        }

    }
}
