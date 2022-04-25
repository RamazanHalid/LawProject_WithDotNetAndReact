using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.DTOs;
using Entities.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            this.logger = logger;
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto, int licenceId = 0)
        {
            logger.LogInformation("Info");
            logger.LogTrace("Trace");
            logger.LogDebug("Debug");
            logger.LogWarning("Warning");
            logger.LogError("Error");
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            if (licenceId > 0)
            {
                var checkLicenceExistance = _authService.CheckLicenceExistance(userToLogin.Data.Id, licenceId);
                if (!checkLicenceExistance.Success)
                    return BadRequest(checkLicenceExistance);
                var result = _authService.CreateAccessToken(userToLogin.Data, licenceId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            var userIdResult = _authService.UserAfterLogin(userToLogin.Data.Id);
            if (userIdResult.Success)
            {
                return Ok(userIdResult);
            }
            return BadRequest(userIdResult);
        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.CellPhone);
            if (userExists.Success)
            {
                return Ok(userExists);
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

        [HttpGet("ApproveEmail")]
        public ActionResult ApproveEmail(int userId, Guid approveGuid)
        {
            var approvingUserResult = _authService.ApprovingSelectedUserEmail(userId, approveGuid);
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
        [HttpGet("GetUserInfo")]
        public ActionResult GetUserInfo()
        {
            var result = _authService.GetUserInfo();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("UpdateUserProfile")]
        public ActionResult UpdateUserProfile(UpdateUserDto updateUserDto)
        {
            if (updateUserDto.ProfileImageFile != null)
            {
                var uploadImageResult = FileHelper.Add(updateUserDto.ProfileImageFile, "UserProfileImages");
                if (uploadImageResult.Success)
                {
                    updateUserDto.ProfileImage = uploadImageResult.Data;
                }
                else
                {
                    return BadRequest(uploadImageResult);
                }
            }
            var result = _authService.UpdateUser(updateUserDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
