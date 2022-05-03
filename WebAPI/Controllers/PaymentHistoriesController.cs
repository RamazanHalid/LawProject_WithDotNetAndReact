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

        [HttpGet("GetAllAsAdmin")]
        public IActionResult GetAllAsAdmin(int pageNumber, int pageSize,int licenceId)
        {
            var result = _PaymentHistoryService.GetAllAsAdminWithFilter(pageNumber, pageSize, licenceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
