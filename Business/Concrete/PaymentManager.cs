using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly ILicenceService _licenceService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPaymentHistoryService _paymentHistoryService;
        private readonly ICreditCardReminderService _creditCardReminderService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        List<BankCreditCardInfo> CreditCardsInBankSimulation = new List<BankCreditCardInfo>()
            {
                new BankCreditCardInfo()
                {
                    CreditCardId = 1,
                    FullName = "Ramazan Halid",
                    CreditCardNo = "1111111111111111",
                    LatestMonth = 10,
                    LatestYear = 2026,
                    SecurityCode = 331,
                    TotalBalance = 1450.078f
                },
                new BankCreditCardInfo()
                {
                    CreditCardId = 2,
                    FullName = "Samin Taheri",
                    CreditCardNo = "2222222222222222",
                    LatestMonth = 9,
                    LatestYear = 2024,
                    SecurityCode = 678,
                    TotalBalance = 10.75f
                }
            };
        public PaymentManager(ILicenceService licenceService, ICurrentUserService currentUserService,
            IPaymentHistoryService paymentHistoryService, ICreditCardReminderService creditCardReminderService,
            IEmailService emailService, IUserService userService)
        {
            _licenceService = licenceService;
            _currentUserService = currentUserService;
            _paymentHistoryService = paymentHistoryService;
            _creditCardReminderService = creditCardReminderService;
            _emailService = emailService;
            _userService = userService;
        }
        [SecuredOperation("LicenceOwner")]
        [ValidationAspect(typeof(PaymentDetailValidator))]
        public IResult MakePayment(PaymentDetail paymentDetail)
        {
            var bankCreditCard = CreditCardsInBankSimulation.Find(w => w.CreditCardNo == paymentDetail.CreditCardNo);
            if (bankCreditCard == null)
                return new ErrorResult("This credit card doesn't exist!");
            if (bankCreditCard.SecurityCode != paymentDetail.SecurityCode
                && bankCreditCard.LatestMonth != paymentDetail.LatestMonth
                && bankCreditCard.LatestYear != paymentDetail.LatestYear
                && bankCreditCard.FullName != paymentDetail.FullName
                )
                return new ErrorResult("This credit card doesn't exist!");
            if (paymentDetail.HowMuchBalanceLoaded > bankCreditCard.TotalBalance)
                return new ErrorResult("You don't have enough balance!");
            _licenceService.AddBalance(_currentUserService.GetLicenceId(), paymentDetail.HowMuchBalanceLoaded);
            _paymentHistoryService.Add(new PaymentHistory
            {
                Balance = paymentDetail.HowMuchBalanceLoaded,
                LicenceId = _currentUserService.GetLicenceId(),
                PaymentDate = DateTime.Now
            });
            _emailService.Send(new EmailContent
            {
                Message = $"The payment is successful, {paymentDetail.HowMuchBalanceLoaded} has been loaded into your account!",
                Subject = "Medilaw Payment",
                To = _userService.GetByUserId(_currentUserService.GetUserId()).Email,
            });
            return new SuccessResult("Payment Successfuly");
        }

        public IResult MakePaymentWithCreditCardId(int creditCardId, int howMuchBalance)
        {

            var paymentDetail = _creditCardReminderService.GetById(creditCardId).Data;
            var bankCreditCard = CreditCardsInBankSimulation.Find(w => w.CreditCardNo == paymentDetail.CreditCardNo);
            if (bankCreditCard == null)
                return new ErrorResult("This credit card doesn't exist!");
            if (bankCreditCard.SecurityCode != paymentDetail.SecurityCode
                && bankCreditCard.LatestMonth != paymentDetail.LatestMonth
                && bankCreditCard.LatestYear != paymentDetail.LatestYear
                && bankCreditCard.FullName != paymentDetail.FullName
                )
                return new ErrorResult("This credit card doesn't exist!");
            if (howMuchBalance > bankCreditCard.TotalBalance)
                return new ErrorResult("You don't have enough balance!");
            _licenceService.AddBalance(_currentUserService.GetLicenceId(), howMuchBalance);
            _paymentHistoryService.Add(new PaymentHistory
            {
                Balance = howMuchBalance,
                LicenceId = _currentUserService.GetLicenceId(),
                PaymentDate = DateTime.Now
            });
            _emailService.Send(new EmailContent
            {
                Message = $"The payment is successful, {howMuchBalance} has been loaded into your account!",
                Subject = "Medilaw Payment",
                To = _userService.GetByUserId(_currentUserService.GetUserId()).Email,
            });
            return new SuccessResult("Payment Successfuly");
        }
    }
}
