using Entities.DTOs.CaseTypeDtos;
using Entities.DTOs.EventTypeDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EventTypeAddDtoValidator : AbstractValidator<EventTypeAddDto>
    {
        public EventTypeAddDtoValidator()
        {
            RuleFor(c => c.EventTypeName).MinimumLength(3);
        }
    }
}
