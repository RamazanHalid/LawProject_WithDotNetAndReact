using Entities.DTOs;
using Entities.DTOs.ProcessType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
