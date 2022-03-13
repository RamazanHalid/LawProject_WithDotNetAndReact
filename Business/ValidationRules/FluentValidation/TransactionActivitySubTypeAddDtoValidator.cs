﻿using Entities.DTOs;
using Entities.DTOs.ProcessType;
using Entities.DTOs.TransactionActivitySubType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class TransactionActivitySubTypeAddDtoValidator : AbstractValidator<TransactionActivitySubTypeAddDto>
    {
        public TransactionActivitySubTypeAddDtoValidator()
        {
            RuleFor(c => c.TransactionAcitivitySubTypeName).MinimumLength(3);
            RuleFor(c => c.TransactionAcitivityTypeId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
        }
    }
}