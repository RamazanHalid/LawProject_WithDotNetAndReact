using Business.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("SendEmailToCustomers")]
        public IActionResult SendEmailToCustomers(SendMessageWithIds sendMessageWithIds)
        {
            var result = _emailService.SendEmailToCustomers(sendMessageWithIds);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("SendEmailToMembers")]
        public IActionResult SendEmailToMembers(SendMessageWithIds sendMessageWithIds)
        {
            var result = _emailService.SendEmailToMembers(sendMessageWithIds);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("SendEmail")]
        public IActionResult SendEmails(EmailMultipleReciver emailMultipleReciver)
        {
            var result = _emailService.SendMessageWithList(emailMultipleReciver);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
