using Entities.DTOs.LicenceUserDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LicenceUserUpdateDtoValidator : AbstractValidator<LicenceUserUpdateDto>
    {
        public LicenceUserUpdateDtoValidator()
        {
            RuleFor(c => c.LicenceUserId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
        }
    }
}
