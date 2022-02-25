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
        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
            var resultAllLicences = _authService.UserAfterLogin(userToLogin.Data.Id);
            if (resultAllLicences.Success)
            {
                return Ok(resultAllLicences);
            }
            return BadRequest(resultAllLicences);
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
