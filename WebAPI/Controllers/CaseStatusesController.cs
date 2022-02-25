using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseStatusesController : ControllerBase
    {
        private readonly ICaseStatusService _caseStatusService;
        public CaseStatusesController(ICaseStatusService caseStatusService)
        {
            _caseStatusService = caseStatusService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _caseStatusService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllActive")]
        public IActionResult GetAllActive()
        {
            var result = _caseStatusService.GetAllActive();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _caseStatusService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(CaseStatusAddDto caseStatusAddDto)
        {
            var result = _caseStatusService.Add(caseStatusAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CaseStatusUpdateDto caseStatusUpdateDto)
        {
            var result = _caseStatusService.Update(caseStatusUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeActivity")]
        public IActionResult ChangeActivity(int id)
        {
            var result = _caseStatusService.ChangeActivity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
