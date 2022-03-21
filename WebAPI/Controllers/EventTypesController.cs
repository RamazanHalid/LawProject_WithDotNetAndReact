using Business.Abstract;
using Entities.DTOs.EventTypeDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypesController : ControllerBase
    {
        private IEventTypeService _eventTypeService;
        public EventTypesController(IEventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _eventTypeService.GetAll();
            if (result.Success)
            {
                return await Task.FromResult(Ok(result));
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _eventTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _eventTypeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(EventTypeAddDto eventTypeAddDto)
        {
            var result = _eventTypeService.Add(eventTypeAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(EventTypeUpdateDto eventTypeUpdateDto)
        {
            var result = _eventTypeService.Update(eventTypeUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
