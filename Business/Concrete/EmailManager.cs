using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Entities;
using Entities.DTOs;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Business.Concrete
{
    public class EmailManager : IEmailService
    {
        private readonly ICustomerService _customerService;
        private readonly ILicenceUserService _licenceUserService;

        public EmailManager(ICustomerService customerService, ILicenceUserService licenceUserService)
        {
            _customerService = customerService;
            _licenceUserService = licenceUserService;
        }
        //Sending mail to selected Customers by customer Ids
        [SecuredOperation("LicenceOwner,SendEmailToCustomer")]
        [ValidationAspect(typeof(SendMessageWithIdsValidator))]
        public IResult SendEmailToCustomers(SendMessageWithIds sendMessageWithIds)
        {
            List<string> recipients = new List<string>();
            foreach (var item in sendMessageWithIds.Ids)
            {
                var re = _customerService.GetById(item);
                if (!re.Success)
                    return re;
                recipients.Add(re.Data.Email);
            }
            var result = SendMessageWithList(new EmailMultipleReciver
            {
                ContentFile = null,
                Subject = sendMessageWithIds.Title,
                Message = sendMessageWithIds.Message,
                Tos = recipients
            });
            if (!result.Success)
                return result;
            return new SuccessResult("Emails Sended");
        }
        //Sending mail to selected Customers by customer Ids
        [SecuredOperation("LicenceOwner,SendEmailToMember")]
        [ValidationAspect(typeof(SendMessageWithIdsValidator))]
        public IResult SendEmailToMembers(SendMessageWithIds sendMessageWithIds)
        {
            List<string> recipients = new List<string>();
            foreach (var item in sendMessageWithIds.Ids)
            {
                var re = _licenceUserService.GetById(item);
                if (!re.Success)
                    return re;
                recipients.Add(re.Data.Email);
            }
            var result = SendMessageWithList(new EmailMultipleReciver
            {
                ContentFile = null,
                Subject = sendMessageWithIds.Title,
                Message = sendMessageWithIds.Message,
                Tos = recipients
            });
            if (!result.Success)
                return result;
            return new SuccessResult("Emails Sended");
        }
        [ValidationAspect(typeof(EmailContentValidator))]
        public IResult Send(EmailContent emailContent)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Credentials = new NetworkCredential("", "");
            MailMessage mailMessage = new MailMessage() { };
            mailMessage.From = new MailAddress("", "");
            mailMessage.Body = emailContent.Message;
            mailMessage.To.Add(emailContent.To);
            mailMessage.Subject = emailContent.Subject;
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);
            return new SuccessResult("Email Sended");
        }
        [ValidationAspect(typeof(EmailMultipleReciverValidator))]
        public IResult SendMessageWithList(EmailMultipleReciver emailMultipleReciver)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Credentials = new NetworkCredential("", "");
            MailMessage mailMessage = new MailMessage() { };
            mailMessage.From = new MailAddress("", "");
            foreach (var item in emailMultipleReciver.Tos)
            {
                mailMessage.To.Add(item);
            }
            mailMessage.Body = emailMultipleReciver.Message;
            mailMessage.Subject = emailMultipleReciver.Subject;
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);
            return new SuccessResult("Email Sended");
        }
    }
}
