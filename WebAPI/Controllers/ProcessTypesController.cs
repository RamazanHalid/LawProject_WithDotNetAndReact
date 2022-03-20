using Business.Abstract;
using Entities.DTOs.ProcessTypeDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessTypesController : ControllerBase
    {
        private IProcessTypeService _processTypeService;

        public ProcessTypesController(IProcessTypeService processTypeService)
        {
            _processTypeService = processTypeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _processTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(ProcessTypeAddDto processTypeAddDto)
        {
            var result = _processTypeService.Add(processTypeAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(ProcessTypeUpdateDto processTypeUpdateDto)
        {
            var result = _processTypeService.Update(processTypeUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllActive")]
        public IActionResult GetAllActive()
        {
            var result = _processTypeService.GetAllActive();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _processTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeActivity")]
        public IActionResult ChangeActivity(int id)
        {
            var result = _processTypeService.ChangeActivity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
