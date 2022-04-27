using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.EventtDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventtsController : ControllerBase
    {
        private readonly IEventtService _eventtService;
        public EventtsController(IEventtService eventtService)
        {
            _eventtService = eventtService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _eventtService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllLastEventsByNumber")]
        public IActionResult GetAllLastEventsByNumber(int number)
        {
            var result = _eventtService.GetAllLastEventsByNumber(number);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllActive")]
        public IActionResult GetAllActive()
        {
            var result = _eventtService.GetAllActive();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _eventtService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(EventtAddDto eventtAddDto)
        {
            var result = _eventtService.Add(eventtAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(EventtUpdateDto eventtUpdateDto)
        {
            var result = _eventtService.Update(eventtUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeActivity")]
        public IActionResult ChangeActivity(int id)
        {
            var result = _eventtService.ChangeActivity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
