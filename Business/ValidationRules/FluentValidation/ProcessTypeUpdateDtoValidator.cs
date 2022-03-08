using Entities.DTOs;
using Entities.DTOs.ProcessType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProcessTypeUpdateDtoValidator : AbstractValidator<ProcessTypeUpdateDto>
    {
        public ProcessTypeUpdateDtoValidator()
        {
            RuleFor(c => c.ProcessTypeName).MinimumLength(3);
            RuleFor(c => c.ProcessTypeId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
        }
    }
}
