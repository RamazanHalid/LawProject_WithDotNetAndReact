using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Add(CourtOfficeType courtOfficeType)
        {
            var result = _courtOfficeTypeService.Add(courtOfficeType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CourtOfficeType courtOfficeType)
        {
            var result = _courtOfficeTypeService.Update(courtOfficeType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
