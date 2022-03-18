using Entities.DTOs.CaseStatusDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CaseStatusAddDtoValidator : AbstractValidator<CaseStatusAddDto>
    {
        public CaseStatusAddDtoValidator()
        {
            RuleFor(c => c.CourtOfficeTypeId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.Description).MinimumLength(2);
        }
    }
}
