using AutoMapper;
using Business.Abstract;
using Entities.DTOs.AccountActivityTypeDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     class AccountActivityTypesController : ControllerBase
    {
        private readonly IAccountActivityTypeService _accountActivityTypeService;
        public AccountActivityTypesController(IAccountActivityTypeService accountActivityTypeService)
        {
            _accountActivityTypeService = accountActivityTypeService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _accountActivityTypeService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _accountActivityTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(AccountActivityTypeAddDto accountActivityTypeAddDto)
        {
            var result = _accountActivityTypeService.Add(accountActivityTypeAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(AccountActivityTypeUpdateDto accountActivityTypeUpdateDto)
        {
            var result = _accountActivityTypeService.Update(accountActivityTypeUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
