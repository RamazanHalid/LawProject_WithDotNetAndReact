using Business.Abstract;
using Entities.DTOs.LicenceUserDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenceUsersController : ControllerBase
    {
        private ILicenceUserService _licenceUser;
        public LicenceUsersController(ILicenceUserService licenceUser)
        {
            _licenceUser = licenceUser;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _licenceUser.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("UsersForIgnore")]
        public IActionResult UsersForIgnore()
        {
            var result = _licenceUser.UsersForIgnore();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllAcceptedByUserId")]
        public IActionResult GetAllAcceptedByUserId(int userId)
        {
            var result = _licenceUser.GetAllAcceptByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllAuthUser")]
        public IActionResult GetAllAuthUser()
        {
            var result = _licenceUser.GetAllByUserId();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _licenceUser.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("ChangeAcceptence")]
        public IActionResult ChangeAcceptence(int id)
        {
            var result = _licenceUser.ChangeAcceptence(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(LicenceUserAddDto licenceUserAddDto)
        {
            var result = _licenceUser.Add(licenceUserAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(LicenceUserUpdateDto licenceUserUpdateDto)
        {
            var result = _licenceUser.Update(licenceUserUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
