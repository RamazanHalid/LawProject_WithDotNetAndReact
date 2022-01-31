using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("GetByLicenceId")]
        public IActionResult GetByLicenceId(int licenceId)
        {
            var result = _licenceUser.GetByLicenceId(licenceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _licenceUser.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(LicenceUser licenceUser)
        {
            var result = _licenceUser.Add(licenceUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(LicenceUser licenceUser)
        {
            var result = _licenceUser.Update(licenceUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _licenceUser.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
