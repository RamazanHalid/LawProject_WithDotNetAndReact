using Business.Abstract;
using Entities.DTOs.SmsOrderDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsOrdersController : ControllerBase
    {
        private ISmsOrderService _smsOrderService;
        public SmsOrdersController(ISmsOrderService smsOrderService)
        {
            _smsOrderService = smsOrderService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _smsOrderService.GetAll();
            if (result.Success)
            {
                return await Task.FromResult(Ok(result));
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _smsOrderService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _smsOrderService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("BuyTheSms")]
        public IActionResult BuyTheSms(int id)
        {
            var result = _smsOrderService.BuyTheSms(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(SmsOrderAddDto smsOrderAddDto)
        {
            var result = _smsOrderService.Add(smsOrderAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(SmsOrderUpdateDto smsOrderUpdateDto)
        {
            var result = _smsOrderService.Update(smsOrderUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
