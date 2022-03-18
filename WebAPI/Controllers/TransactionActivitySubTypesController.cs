using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.TransactionActivitySubType;
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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _transactionActivitySubTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByTransactionActivityTypeId")]
        public IActionResult GetAllByTransactionActivityId(int id)
        {
            var result = _transactionActivitySubTypeService.GetAllByTransactionActovotyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllActive")]
        public IActionResult GetAllActive()
        {
            var result = _transactionActivitySubTypeService.GetAllActive();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _transactionActivitySubTypeService.GetById(id);
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

        [HttpGet("ChangeActivity")]
        public IActionResult ChangeActivity(int id)
        {
            var result = _transactionActivitySubTypeService.ChangeActivity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(TransactionActivitySubTypeAddDto transactionActivitySubTypeDto)
        {
            var result = _transactionActivitySubTypeService.Add(transactionActivitySubTypeDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(TransactionActivitySubTypeUpdateDto transactionActivitySubTypeDto)
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
