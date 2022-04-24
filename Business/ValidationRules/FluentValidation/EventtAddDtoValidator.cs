using Entities.DTOs.EventtDtos;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class EventtAddDtoValidator : AbstractValidator<EventtAddDto>
    {
        public EventtAddDtoValidator()
        {
            RuleFor(c => c.EventTypeId).GreaterThan(0);
            RuleFor(c => c.CaseeId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.StartDate).GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(c => c.EndDate).GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(c => c.EventTypeId).GreaterThan(0);
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.CustomerId).GreaterThan(0);
            RuleFor(c => c.Info).MinimumLength(10);
        }
    }
}
