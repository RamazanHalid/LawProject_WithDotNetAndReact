using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicencesController : ControllerBase
    {
        private ILicenceService _licenceService;
        public LicencesController(ILicenceService licenceService)
        {
            _licenceService = licenceService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _licenceService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(Licence licence)
        {
            var result = _licenceService.Add(licence);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
