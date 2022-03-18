using Entities.DTOs.CaseStatusDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CaseStatusUpdateDtoValidator : AbstractValidator<CaseStatusUpdateDto>
    {
        public CaseStatusUpdateDtoValidator()
        {
            RuleFor(c => c.CaseStatusId).GreaterThan(0);
            RuleFor(c => c.CourtOfficeTypeId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.Description).MinimumLength(2);
        }
    }
}
