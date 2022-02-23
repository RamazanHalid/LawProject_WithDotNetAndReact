using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Add(LicenceAddDto licenceAddDto)
        {
            if (licenceAddDto.ImageFile != null)
            {
                var imageResult = FileHelper.Add(licenceAddDto.ImageFile, "LicenceImages");
                if (imageResult.Success)
                {
                    licenceAddDto.Image = imageResult.Data;
                }
            }
            else
            {
                licenceAddDto.Image = "/Uploads/LicenceImages/NoLicenceImage.jpg";
            }
            var result = _licenceService.Add(licenceAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
