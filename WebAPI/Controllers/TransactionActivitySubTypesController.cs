using Business.Abstract;
using Entities.Concrete;
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
        public IActionResult GetAllByLicenceIdWithTransactionActivityType(int licenceId, int isActive)
        {
            var result = _transactionActivitySubTypeService.GetAllByLicenceIdWithTransactionActivityType(licenceId, isActive);
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
        public IActionResult Add(TransactionActivitySubType transactionActivitySubType)
        {
            var result = _transactionActivitySubTypeService.Add(transactionActivitySubType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(TransactionActivitySubType transactionActivitySubType)
        {
            var result = _transactionActivitySubTypeService.Update(transactionActivitySubType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
