using Business.Abstract;
using Entities.DTOs.CaseeDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseesController : ControllerBase
    {
        private ICaseeService _caseeService;

        public CaseesController(ICaseeService caseeService)
        {
            _caseeService = caseeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _caseeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _caseeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(CaseeAddDto caseeAddDto)
        {
            var result = _caseeService.Add(caseeAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CaseeUpdateDto caseeUpdateDto)
        {
            var result = _caseeService.Update(caseeUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _caseeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeStatus")]
        public IActionResult ChangeStatus(int id, int caseStatusId)
        {
            var result = _caseeService.ChangeStatus(id, caseStatusId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
