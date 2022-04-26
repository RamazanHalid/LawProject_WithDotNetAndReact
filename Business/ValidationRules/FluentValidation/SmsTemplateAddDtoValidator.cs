using Entities.DTOs.SmsTemplateDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SmsTemplateAddDtoValidator : AbstractValidator<SmsTemplateAddDto>
    {
        public SmsTemplateAddDtoValidator()
        {
            RuleFor(c => c.Message).NotEmpty().MaximumLength(100);
            RuleFor(c => c.SmsHeader).NotEmpty().MaximumLength(20);
        }
    }
}
