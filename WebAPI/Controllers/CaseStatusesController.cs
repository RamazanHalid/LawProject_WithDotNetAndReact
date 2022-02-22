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
        [HttpGet("GetAllByLicenceIdAndActivity")]
        public IActionResult GetAllByLicenceIdAndActivity(int isActive)
        {
            var result = _caseStatusService.GetAllByLicenceIdAndActivity(isActive);

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
        public IActionResult Add(CaseStatusDto caseStatusDto)
        {
            var result = _caseStatusService.Add(caseStatusDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CaseStatusDto caseStatusDto)
        {
            var result = _caseStatusService.Update(caseStatusDto);
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
