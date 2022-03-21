using Business.Abstract;
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
    }
}
