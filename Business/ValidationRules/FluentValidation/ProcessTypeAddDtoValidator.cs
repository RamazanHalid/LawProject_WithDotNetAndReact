using Entities.DTOs;
using Entities.DTOs.ProcessType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
