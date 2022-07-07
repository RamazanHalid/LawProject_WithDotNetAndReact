using Business.Abstract;
using Entities.DTOs.TaskTypeDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTypesController : ControllerBase
    {
        private ITaskTypeService _taskTypeService;

        public TaskTypesController(ITaskTypeService taskTypeService)
        {
            _taskTypeService = taskTypeService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _taskTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllActive")]
        public IActionResult GetAllActive()
        {
            var result = _taskTypeService.GetAllActive();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _taskTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeActivity")]
        public IActionResult ChangeActivity(int id)
        {
            var result = _taskTypeService.ChangeActivity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _taskTypeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(TaskTypeAddDto taskTypeAddDto)
        {
            var result = _taskTypeService.Add(taskTypeAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(TaskTypeUpdateDto taskTypeUpdateDto)
        {
            var result = _taskTypeService.Update(taskTypeUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
