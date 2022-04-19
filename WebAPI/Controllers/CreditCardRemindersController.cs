using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs.CreditCardReminderDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardRemindersController : ControllerBase
    {
        private readonly ICreditCardReminderService _creditCardReminderService;
        public CreditCardRemindersController(ICreditCardReminderService creditCardReminderService)
        {
            _creditCardReminderService = creditCardReminderService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _creditCardReminderService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _creditCardReminderService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(CreditCardReminderAddDto creditCardReminderAddDto)
        {
            var result = _creditCardReminderService.Add(creditCardReminderAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("CheckCreditCardIsExist")]
        public IActionResult CheckCreditCardIsExist(CreditCardNoHolder creditCardNoHolder)
        {
            var result = _creditCardReminderService.CheckTheCardIsExist(creditCardNoHolder.CreditCardNo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CreditCardReminderUpdateDto creditCardReminderUpdateDto)
        {
            var result = _creditCardReminderService.Update(creditCardReminderUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
