using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionActivitySubTypesController : ControllerBase
    {
        private ITransactionActivitySubTypeService _transactionActivitySubTypeService;

        public TransactionActivitySubTypesController(ITransactionActivitySubTypeService transactionActivityTypeService)
        {
            _transactionActivitySubTypeService = transactionActivityTypeService;
        }

        [HttpGet("GetAllByLicenceIdWithTransactionActivityType")]
        public IActionResult GetAllByLicenceIdWithTransactionActivityType(int isActive)
        {
            var result = _transactionActivitySubTypeService.GetAllByLicenceIdWithTransactionActivityType(isActive);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdWithTransactionActivityType")]
        public IActionResult GetByIdWithTransactionActivityType(int id)
        {
            var result = _transactionActivitySubTypeService.GetByIdWithTransactionActivityType(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _transactionActivitySubTypeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(TransactionActivitySubTypeDto transactionActivitySubTypeDto)
        {
            var result = _transactionActivitySubTypeService.Add(transactionActivitySubTypeDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(TransactionActivitySubTypeDto transactionActivitySubTypeDto)
        {
            var result = _transactionActivitySubTypeService.Update(transactionActivitySubTypeDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
