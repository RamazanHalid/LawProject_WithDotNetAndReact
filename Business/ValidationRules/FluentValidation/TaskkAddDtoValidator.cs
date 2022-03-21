using Entities.DTOs.TaskkDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TaskkAddDtoValidator : AbstractValidator<TaskkAddDto>
    {
        public TaskkAddDtoValidator()
        {
            RuleFor(c => c.CaseId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.CustomerId).GreaterThan(0);
            RuleFor(c => c.TaskTypeId).GreaterThan(0);
            RuleFor(c => c.Info).MinimumLength(10);
        }
    }
}
