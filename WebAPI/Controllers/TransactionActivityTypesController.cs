using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionActivityTypesController : ControllerBase
    {
        private ITransactionActivityTypeService _transactionActivityTypeService;

        public TransactionActivityTypesController(ITransactionActivityTypeService transactionActivityTypeService)
        {
            _transactionActivityTypeService = transactionActivityTypeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _transactionActivityTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _transactionActivityTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _transactionActivityTypeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(TransactionActivityType transactionActivityType)
        {
            var result = _transactionActivityTypeService.Add(transactionActivityType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(TransactionActivityType transactionActivityType)
        {
            var result = _transactionActivityTypeService.Update(transactionActivityType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
