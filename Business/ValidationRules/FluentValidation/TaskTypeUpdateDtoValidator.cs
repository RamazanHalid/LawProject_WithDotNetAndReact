using Entities.DTOs.TaskTypeDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TaskTypeUpdateDtoValidator : AbstractValidator<TaskTypeUpdateDto>
    {
        public TaskTypeUpdateDtoValidator()
        {
            RuleFor(c => c.TaskTypeName).MinimumLength(3);
            RuleFor(c => c.TaskTypeId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
        }
    }
}
