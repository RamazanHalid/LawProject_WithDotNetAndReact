using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTypesController : ControllerBase
    {
        private IPersonTypeService _personTypeService;

        public PersonTypesController(IPersonTypeService personTypeService)
        {
            _personTypeService = personTypeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _personTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _personTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
