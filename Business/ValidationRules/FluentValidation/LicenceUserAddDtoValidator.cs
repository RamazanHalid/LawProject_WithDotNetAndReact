using Entities.DTOs.LicenceUserDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LicenceUserAddDtoValidator : AbstractValidator<LicenceUserAddDto>
    {
        public LicenceUserAddDtoValidator()
        {
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
        }
    }
}
