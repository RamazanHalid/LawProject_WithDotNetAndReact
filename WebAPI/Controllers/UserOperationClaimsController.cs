using Business.Abstract;
using Entities.DTOs.UserOperationClaimDtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int userId)
        {
            var result = _userOperationClaimService.GetAllIds(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddAsList")]
        public IActionResult AddAsList(int userId, List<int> operationClaimIds)
        {
            var result = _userOperationClaimService.AddAsList(userId, operationClaimIds);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
