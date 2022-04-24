using Business.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISmsService _smsService;

        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost("SendSmsToCustomers")]
        public IActionResult SendSmsToCustomers(SendMessageWithIds sendMessageWithIds)
        {
            var result = _smsService.SendSmsToCustomers(sendMessageWithIds.Title + "\n" + sendMessageWithIds.Message, sendMessageWithIds.Ids);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("SendSmsToMembers")]
        public IActionResult SendSmsToMembers(SendMessageWithIds sendMessageWithIds)
        {
            var result = _smsService.SendSmsToMembers(sendMessageWithIds.Title + "\n" + sendMessageWithIds.Message, sendMessageWithIds.Ids);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("SendSms")]
        public IActionResult SendSmss(SmsMultipleReciver smsMultipleReciver)
        {
            var result = _smsService.SendMessageWithList(smsMultipleReciver.Title + "\n" + smsMultipleReciver.Message, smsMultipleReciver.Tos);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
