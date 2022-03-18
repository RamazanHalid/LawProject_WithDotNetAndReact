using Entities.DTOs.TransactionActivitySubTypeDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TransactionActivitySubTypeAddDtoValidator : AbstractValidator<TransactionActivitySubTypeAddDto>
    {
        public TransactionActivitySubTypeAddDtoValidator()
        {
            RuleFor(c => c.TransactionActivitySubTypeName).MinimumLength(3);
            RuleFor(c => c.TransactionActivityTypeId).GreaterThan(0);
            RuleFor(c => c.IsActive).NotNull();
        }
    }
}
