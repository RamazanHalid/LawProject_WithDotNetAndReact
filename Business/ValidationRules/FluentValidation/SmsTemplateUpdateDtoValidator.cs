using Entities.DTOs.SmsTemplateDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SmsTemplateUpdateDtoValidator : AbstractValidator<SmsTemplateUpdateDto>
    {
        public SmsTemplateUpdateDtoValidator()
        {
            RuleFor(c => c.SmsTemplateId).GreaterThan(0);
            RuleFor(c => c.Message).NotEmpty().MaximumLength(100);
            RuleFor(c => c.SmsHeader).NotEmpty().MaximumLength(20);
        }
    }
}
