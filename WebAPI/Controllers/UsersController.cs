using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUserExceptAlreadyRecordedUsersInLicence")]
        public IActionResult GetAllUserExceptAlreadyRecordedUsersInLicence()
        {
            var result = _userService.GetAllUsersForAddingOtherLicence();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("GetAllUsersAsAdmin")]
        public IActionResult GetAllUsersAsAdmin(int pageNumber, int pageSize, UserFilterAsAdmin userFilterAsAdmin)
        {
            var result = _userService.GetAllAsAdmin(pageNumber, pageSize, userFilterAsAdmin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByUserIdAsAdmin")]
        public IActionResult GetByUserIdAsAdmin(int id)
        {
            var result = _userService.GetUserDetailsAsAdmin(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
