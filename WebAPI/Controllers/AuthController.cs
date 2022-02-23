using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILicenceUserService _licenceUserService;
        public AuthController(IAuthService authService, ILicenceUserService licenceUserService)
        {
            _authService = authService;
            _licenceUserService = licenceUserService;
        }
        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto, int licenceId = 0)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }
            if (licenceId > 0)
            {
                var result = _authService.CreateAccessToken(userToLogin.Data, licenceId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            var licenceUser = _licenceUserService.GetByUserIdManualy(userToLogin.Data.Id);
            if (licenceUser.Success)
            {
                return Ok(licenceUser);
            }
            return BadRequest(licenceUser);
        }
        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.CellPhone);
            if (userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var result = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("approvingUser")]
        public ActionResult ApprovingUser(ApprovingUserDto approvingUserDto)
        {
            var approvingUserResult = _authService.ApprovingSelectedUser(approvingUserDto);
            if (!approvingUserResult.Success)
            {
                return BadRequest(approvingUserResult);
            }
            return Ok(approvingUserResult);
        }
        [HttpPost("ForgetPassword")]
        public ActionResult ForgetPassword(string cellPhone)
        {
            var result = _authService.ForgetPassword(cellPhone);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("UpdateUserPassword")]
        public ActionResult UpdateUserPassword(UpdateUserPasswordDto updateUserPasswordDto)
        {
            var result = _authService.UpdateUserPassword(updateUserPasswordDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
