using Entities.DTOs.TaskkDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TaskkUpdateDtoValidator : AbstractValidator<TaskkUpdateDto>
    {
        public TaskkUpdateDtoValidator()
        {
            RuleFor(c => c.TaskkId).GreaterThan(0);
            RuleFor(c => c.CaseId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.CustomerId).GreaterThan(0);
            RuleFor(c => c.TaskTypeId).GreaterThan(0);
            RuleFor(c => c.Info).MinimumLength(10);
        }
    }
}
