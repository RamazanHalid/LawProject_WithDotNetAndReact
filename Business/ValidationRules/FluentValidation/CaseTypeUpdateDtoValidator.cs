using Entities.DTOs.CaseTypeDtos;
using FluentValidation;

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
