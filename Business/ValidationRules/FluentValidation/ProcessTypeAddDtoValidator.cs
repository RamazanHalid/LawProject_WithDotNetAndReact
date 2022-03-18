using Entities.DTOs.ProcessTypeDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProcessTypeAddDtoValidator : AbstractValidator<ProcessTypeAddDto>
    {
        public ProcessTypeAddDtoValidator()
        {
            RuleFor(c => c.ProcessTypeName).MinimumLength(3);
            RuleFor(c => c.IsActive).NotNull();
        }
    }
}
