using Entities.DTOs;
using Entities.DTOs.CourtOffice;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class CourtOfficeAddDtoValidator : AbstractValidator<CourtOfficeAddDto>
    {
        public CourtOfficeAddDtoValidator()
        {
            RuleFor(c => c.CourtOfficeTypeId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.PhoneNumber).Must(CheckPhoneNumber);
            RuleFor(c => c.CourtOfficeName).MinimumLength(3);
            RuleFor(c => c.CityId).GreaterThan(0);
            RuleFor(c => c.Adderess).MinimumLength(15);
        }
        public bool CheckPhoneNumber(string arg)
        {

            return Regex.IsMatch(arg, @"^((\d{11}))$", RegexOptions.IgnoreCase);

        }
    }
}
