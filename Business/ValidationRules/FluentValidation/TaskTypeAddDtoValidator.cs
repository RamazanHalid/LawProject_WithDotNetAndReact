using Entities.DTOs.TaskTypeDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TaskTypeAddDtoValidator : AbstractValidator<TaskTypeAddDto>
    {
        public TaskTypeAddDtoValidator()
        {
            RuleFor(c => c.TaskTypeName).MinimumLength(3);
            RuleFor(c => c.IsActive).NotNull();
        }
    }
}
