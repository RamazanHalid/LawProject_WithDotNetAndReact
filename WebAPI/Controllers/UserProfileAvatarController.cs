using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileAvatarController : ControllerBase
    {

        private readonly IUserProfileAvatarService _userProfileAvatarService;

        public UserProfileAvatarController(IUserProfileAvatarService userProfileAvatarService)
        {
            _userProfileAvatarService = userProfileAvatarService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userProfileAvatarService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
