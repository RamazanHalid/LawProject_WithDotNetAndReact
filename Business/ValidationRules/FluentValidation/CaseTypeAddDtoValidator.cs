using Entities.DTOs.CaseTypeDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CaseTypeAddDtoValidator : AbstractValidator<CaseTypeAddDto>
    {
        public CaseTypeAddDtoValidator()
        {
            RuleFor(c => c.CourtOfficeTypeId).GreaterThan(0).WithMessage("Court office type is required");
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.Description)
                .MinimumLength(2)
                .MaximumLength(250)
                .Must(CheckDoesNotIncludeBadWords)
                .WithMessage("Length of description must be greater than 2 and lower than 250 word.");
            RuleFor(c => c.Description)
                .Must(CheckDoesNotIncludeBadWords).WithMessage("Description contains bad words!");



        }
        private bool CheckDoesNotIncludeBadWords(string args)
        {
            return !args.Contains("badword") ;
        }
    }
}
