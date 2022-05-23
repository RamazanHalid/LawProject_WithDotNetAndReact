using AutoMapper;
using Business.Abstract;
using Entities.DTOs.AccountActivityStatusDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
      class AccountActivityStatusesController : ControllerBase
    {
        private readonly IAccountActivityStatusService _accountActivityStatusService;
        public AccountActivityStatusesController(IAccountActivityStatusService accountActivityStatusService)
        {
            _accountActivityStatusService = accountActivityStatusService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _accountActivityStatusService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _accountActivityStatusService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(AccountActivityStatusAddDto accountActivityStatusAddDto)
        {
            var result = _accountActivityStatusService.Add(accountActivityStatusAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(AccountActivityStatusUpdateDto accountActivityStatusUpdateDto)
        {
            var result = _accountActivityStatusService.Update(accountActivityStatusUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
