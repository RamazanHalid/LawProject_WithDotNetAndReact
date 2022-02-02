using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseTypesController : ControllerBase
    {
        private ICaseTypeService _caseTypeService;

        public CaseTypesController(ICaseTypeService caseTypeService)
        {
            _caseTypeService = caseTypeService;
        }

        [HttpGet("GetAllByLicenceIdAndActivity")]
        public IActionResult GetAllByLicenceIdAndActivity(int licenceId, int isActive)
        {
            var result = _caseTypeService.GetByLicenceIdAndActivity(licenceId, isActive);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _caseTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _caseTypeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeActivity")]
        public IActionResult ChangeActivity(int id)
        {
            var result = _caseTypeService.ChangeActivity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(CaseType caseType)
        {
            var result = _caseTypeService.Add(caseType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CaseType caseType)
        {
            var result = _caseTypeService.Update(caseType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
