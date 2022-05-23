using Business.Abstract;
using Core.Utilities.Helpers;
using Entities;
using Entities.DTOs.LicenceDtos;
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

        [HttpGet("GetLicenceInfoCounts")]
        public IActionResult GetLicenceInfoCounts()
        {
            var result = _licenceService.GetCountInfo();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("GetAllLicencesAsAdmin")]
        public IActionResult GetAllLicencesAsAdmin(int pageNumber, int pageSize, LicenceFilterAsAdmin licenceFilterAsAdmin)
        {
            var result = _licenceService.GetAllAsAdmin(pageNumber, pageSize, licenceFilterAsAdmin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdAsAdmin")]
        public IActionResult GetByIdAsAdmin(int licenceId)
        {
            var result = _licenceService.GetByIdAsAdmin(licenceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByUserId")]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _licenceService.GetAllAfterLogin(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByUserIdAsAdmin")]
        public IActionResult GetAllByUserIdAsAdmin(int userId)
        {
            var result = _licenceService.GetAllByUserIdAsAdmin(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetForUpdating")]
        public IActionResult GetForUpdating()
        {
            var result = _licenceService.GetCurrentAuthUserLicence();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(LicenceAddDto licenceAddDto)
        {

            var result = _licenceService.Add(licenceAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(LicenceUpdateDto licenceUpdateDto)
        {
            if (licenceUpdateDto.ImageFile != null)
            {
                var imageResult = FileHelper.Add(licenceUpdateDto.ImageFile, "LicenceImages");
                if (imageResult.Success)
                {
                    licenceUpdateDto.Image = imageResult.Data;
                }
            }
            else
            {
                licenceUpdateDto.Image = "/Uploads/LicenceImages/NoLicenceImage.jpg";
            }
            var result = _licenceService.Update(licenceUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
