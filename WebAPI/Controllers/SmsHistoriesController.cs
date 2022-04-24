using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsHistoriesController : ControllerBase
    {
        private ISmsHistoryService _smsHistoryService;

        public SmsHistoriesController(ISmsHistoryService smsHistoryService)
        {
            _smsHistoryService = smsHistoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int pageNumber, int pageSize)
        {
            var result = _smsHistoryService.GetAll(pageNumber, pageSize);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
