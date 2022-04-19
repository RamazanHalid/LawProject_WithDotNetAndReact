using Core.Utilities.Results;
using Entities;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IEmailService
    {
        IResult Send(EmailContent emailContent);
        IResult SendMessageWithList(EmailMultipleReciver emailMultipleReciver);
        IResult SendEmailToCustomers(SendMessageWithIds sendMessageWithIds);
        IResult SendEmailToMembers(SendMessageWithIds sendMessageWithIds);
    }
}
