using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseStatusesController : ControllerBase
    {
        private ICaseStatusService _caseStatusService;

        public CaseStatusesController(ICaseStatusService caseStatusService)
        {
            _caseStatusService = caseStatusService;
        }

        [HttpGet("GetAllByLicenceIdAndActivity")]
        public IActionResult GetAllByLicenceIdAndActivity(int licenceId, int isActive)
        {
            var result = _caseStatusService.GetAllByLicenceIdAndActivity(licenceId, isActive);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _caseStatusService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _caseStatusService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(CaseStatus caseStatus)
        {
            var result = _caseStatusService.Add(caseStatus);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CaseStatus caseStatus)
        {
            var result = _caseStatusService.Update(caseStatus);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeActivity")]
        public IActionResult ChangeActivity(int id)
        {
            var result = _caseStatusService.ChangeActivity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
