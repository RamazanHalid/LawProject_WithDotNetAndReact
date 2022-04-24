using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimGroupsController : ControllerBase
    {
        private IOperationClaimGroupService _OperationClaimGroupService;

        public OperationClaimGroupsController(IOperationClaimGroupService OperationClaimGroupService)
        {
            _OperationClaimGroupService = OperationClaimGroupService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _OperationClaimGroupService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    
    }
}
