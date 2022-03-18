using Business.Abstract;
using Entities.DTOs.TransactionActivityDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionActivitiesController : ControllerBase
    {
        private ITransactionActivityService _accountActivityService;

        public TransactionActivitiesController(ITransactionActivityService accountActivityService)
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
        [HttpGet("Approve")]
        public IActionResult Approve(int id)
        {
            var result = _accountActivityService.ApproveTransactionActivity(id);
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
        [HttpPost("Add")]
        public IActionResult Add(TransactionActivityAddDto accountActivityType)
        {
            var result = _accountActivityService.Add(accountActivityType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(TransactionActivityUpdateDto accountActivityType)
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
