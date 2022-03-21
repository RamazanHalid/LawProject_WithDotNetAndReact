using Entities.DTOs.TransactionActivityDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TransactionActivityUpdateDtoValidator : AbstractValidator<TransactionActivityUpdateDto>
    {
        public TransactionActivityUpdateDtoValidator()
        {
            RuleFor(c => c.TransactionActivityId).GreaterThan(0);
            RuleFor(c => c.TransactionActivitySubTypeId).GreaterThan(0);
            RuleFor(c => c.Amount).GreaterThan(0);
            RuleFor(c => c.IsItExpense).NotNull();
            RuleFor(c => c.Info).MinimumLength(10);
        }
    }
}
