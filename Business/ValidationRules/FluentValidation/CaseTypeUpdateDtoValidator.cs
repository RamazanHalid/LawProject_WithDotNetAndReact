using Entities.DTOs;
using Entities.DTOs.CaseType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CaseTypeUpdateDtoValidator : AbstractValidator<CaseTypeUpdateDto>
    {
        public CaseTypeUpdateDtoValidator()
        {
            RuleFor(c => c.CaseTypeId).GreaterThan(0);
            RuleFor(c => c.CourtOfficeTypeId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.Description).MinimumLength(2);
        }
    }
}
