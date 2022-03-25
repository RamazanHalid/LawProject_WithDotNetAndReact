using Business.Abstract;
using Entities.DTOs.RoleTypeDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleTypesController : ControllerBase
    {
        private IRoleTypeService _roleTypeService;
        public RoleTypesController(IRoleTypeService roleTypeService)
        {
            _roleTypeService = roleTypeService;
        }
        [HttpGet("GetAllByCourtOfficeTypeId")]
        public async Task<IActionResult> GetAll(int courtOfficeTypeId)
        {
            var result = _roleTypeService.GetAllByCourtOfficeTypeId(courtOfficeTypeId);
            if (result.Success)
            {
                return await Task.FromResult(Ok(result));
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _roleTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _roleTypeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(RoleTypeAddDto roleTypeAddDto)
        {
            var result = _roleTypeService.Add(roleTypeAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(RoleTypeUpdateDto roleTypeUpdateDto)
        {
            var result = _roleTypeService.Update(roleTypeUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
