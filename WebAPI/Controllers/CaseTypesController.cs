using Business.Abstract;
using Entities.DTOs.CaseTypeDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseTypesController : ControllerBase
    {
        private ICaseTypeService _caseTypeService;
        private ICurrentUserService _currentUserService;
        public CaseTypesController(ICaseTypeService caseTypeService, ICurrentUserService currentUserService)
        {
            _caseTypeService = caseTypeService;
            _currentUserService = currentUserService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _caseTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllActive")]
        public IActionResult GetAllActive()
        {
            var result = _caseTypeService.GetAllActive();
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
        [HttpPost("Add")]
        public IActionResult Add(CaseTypeAddDto caseTypeAddDto)
        {
            var result = _caseTypeService.Add(caseTypeAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CaseTypeUpdateDto caseTypeUpdateDto)
        {
            var result = _caseTypeService.Update(caseTypeUpdateDto);
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

    }
}
