using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentHistoriesController : ControllerBase
    {
        private readonly IPaymentHistoryService _PaymentHistoryService;

        public PaymentHistoriesController(IPaymentHistoryService PaymentHistoryService)
        {
            _PaymentHistoryService = PaymentHistoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _PaymentHistoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
