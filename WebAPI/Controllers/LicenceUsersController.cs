using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.LicenceUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

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
        [HttpGet("GetAllByUserId")]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _licenceUser.GetAllByUserId(userId);
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
