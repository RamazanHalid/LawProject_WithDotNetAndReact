using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CaseStatusAddDtoValidator : AbstractValidator<CaseStatusAddDto>
    {
        public CaseStatusAddDtoValidator()
        {
            RuleFor(c => c.CourtOfficeTypeId).GreaterThan(0);
            RuleFor(c => c.Description).MinimumLength(3);
        }
    }
}
