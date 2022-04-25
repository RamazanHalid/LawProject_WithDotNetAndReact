using Entities.DTOs;
using Entities.DTOs.CaseStatusDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SendMessageWithIdsValidator : AbstractValidator<SendMessageWithIds>
    {
        public SendMessageWithIdsValidator()
        {
            RuleFor(c => c.Title).NotEmpty().MaximumLength(150);
            RuleFor(c => c.Message).NotEmpty().MaximumLength(500);
            RuleFor(c => c.Ids).NotNull().ForEach(c =>c.GreaterThan(0));
        }
    }
}
