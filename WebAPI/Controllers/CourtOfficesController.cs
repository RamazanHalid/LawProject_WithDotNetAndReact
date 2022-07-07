using Business.Abstract;
using Entities.DTOs.CourtOfficeDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtOfficesController : ControllerBase
    {
        private ICourtOfficeService _courtOfficeService;

        public CourtOfficesController(ICourtOfficeService courtOfficeService)
        {
            _courtOfficeService = courtOfficeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _courtOfficeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllCourtOfficeForDropDown")]
        public IActionResult GetAllCourtOfficeForDropDown()
        {
            var result = _courtOfficeService.GetAllCourtOfficesForDropDown();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _courtOfficeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _courtOfficeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeActivity")]
        public IActionResult ChangeActivity(int id)
        {
            var result = _courtOfficeService.ChangeActivity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(CourtOfficeAddDto courtOfficeType)
        {
            var result = _courtOfficeService.Add(courtOfficeType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CourtOfficeUpdateDto courtOfficeType)
        {
            var result = _courtOfficeService.Update(courtOfficeType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
