using Business.Abstract;
using Entities.DTOs.AccountActivityDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountActivitiesController : ControllerBase
    {
        private IAccountActivityService _accountActivityService;

        public AccountActivitiesController(IAccountActivityService accountActivityService)
        {
            _accountActivityService = accountActivityService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _accountActivityService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _accountActivityService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _accountActivityService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ChangeActivity")]
        public IActionResult ChangeActivity(int id)
        {
            var result = _accountActivityService.ChangeActivity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(AccountActivityAddDto accountActivityType)
        {
            var result = _accountActivityService.Add(accountActivityType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(AccountActivityUpdateDto accountActivityType)
        {
            var result = _accountActivityService.Update(accountActivityType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
