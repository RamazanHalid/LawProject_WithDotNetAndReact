using Business.Abstract;
using Entities.DTOs.TaskkDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskksController : ControllerBase
    {
        private ITaskkService _taskkService;

        public TaskksController(ITaskkService taskkService)
        {
            _taskkService = taskkService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _taskkService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _taskkService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeActivity")]
        public IActionResult ChangeActivity(int id)
        {
            var result = _taskkService.ChangeActivity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeStatus")]
        public IActionResult ChangeStatus(int id, int statusId)
        {
            var result = _taskkService.ChangeStatus(id, statusId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _taskkService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(TaskkAddDto taskkAddDto)
        {
            var result = _taskkService.Add(taskkAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(TaskkUpdateDto taskkUpdateDto)
        {
            var result = _taskkService.Update(taskkUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
