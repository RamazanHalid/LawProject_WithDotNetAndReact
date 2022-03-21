using Entities.DTOs.CaseeDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CaseeAddDtoValidator : AbstractValidator<CaseeAddDto>
    {
        public CaseeAddDtoValidator()
        {
            RuleFor(c => c.CourtOfficeTypeId).GreaterThan(0);
            RuleFor(c => c.CaseNo).MinimumLength(1);
            RuleFor(c => c.CaseStatusId).GreaterThan(0);
            RuleFor(c => c.CaseTypeId).GreaterThan(0);
            RuleFor(c => c.CourtOfficeId).GreaterThan(0);
            RuleFor(c => c.CourtOfficeTypeId).GreaterThan(0);
            RuleFor(c => c.CustomerId).GreaterThan(0);
            RuleFor(c => c.RoleTypeId).GreaterThan(0);
            RuleFor(c => c.Info).MinimumLength(10);
        }
    }
}
