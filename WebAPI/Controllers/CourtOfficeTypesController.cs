using Business.Abstract;
using Entities.DTOs.CourtOfficeTypeDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtOfficeTypesController : ControllerBase
    {
        private ICourtOfficeTypeService _courtOfficeTypeService;
        public CourtOfficeTypesController(ICourtOfficeTypeService courtOfficeTypeService)
        {
            _courtOfficeTypeService = courtOfficeTypeService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _courtOfficeTypeService.GetAll();
            if (result.Success)
            {
                return await Task.FromResult(Ok(result));
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _courtOfficeTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _courtOfficeTypeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(CourtOfficeTypeAddDto courtOfficeTypeAddDto)
        {
            var result = _courtOfficeTypeService.Add(courtOfficeTypeAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CourtOfficeTypeUpdateDto courtOfficeTypeUpdateDto)
        {
            var result = _courtOfficeTypeService.Update(courtOfficeTypeUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
