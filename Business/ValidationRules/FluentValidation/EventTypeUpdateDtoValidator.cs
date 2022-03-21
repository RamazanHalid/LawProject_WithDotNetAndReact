using Entities.DTOs.EventTypeDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EventTypeUpdateDtoValidator : AbstractValidator<EventTypeUpdateDto>
    {
        public EventTypeUpdateDtoValidator()
        {
            RuleFor(c => c.EventTypeId).GreaterThan(0);
            RuleFor(c => c.EventTypeName).MinimumLength(3);
        }
    }
}
