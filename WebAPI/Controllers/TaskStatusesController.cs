using Business.Abstract;
using Entities.DTOs.TaskStatusDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusesController : ControllerBase
    {
        private ITaskStatusService _taskStatusService;

        public TaskStatusesController(ITaskStatusService taskStatusService)
        {
            _taskStatusService = taskStatusService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _taskStatusService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _taskStatusService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _taskStatusService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(TaskStatusAddDto taskStatusAddDto)
        {
            var result = _taskStatusService.Add(taskStatusAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(TaskStatusUpdateDto taskStatusUpdateDto)
        {
            var result = _taskStatusService.Update(taskStatusUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
