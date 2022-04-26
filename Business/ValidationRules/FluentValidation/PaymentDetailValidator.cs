using Entities;
using Entities.DTOs.CustomerDtos;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentDetailValidator : AbstractValidator<PaymentDetail>
    {
        public PaymentDetailValidator()
        {
            RuleFor(c => new DateTime(c.LatestYear, c.LatestMonth, 1)).GreaterThanOrEqualTo(DateTime.Now).WithMessage("Date must be bigger than today");
            RuleFor(c => c.HowMuchBalanceLoaded).GreaterThan(0);
            RuleFor(c => c.FullName).NotEmpty().MaximumLength(100);
            RuleFor(c => c.CreditCardNo).Must(CheckCreditCardNo).WithMessage("Credit card no must be 16 digits and all this digits must be number");
        }

        private bool CheckCreditCardNo(string args)
        {
            return Regex.IsMatch(args, @"\d{16}");
        }
    }
}
