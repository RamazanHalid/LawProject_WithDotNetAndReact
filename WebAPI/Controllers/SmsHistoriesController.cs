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

        [HttpGet("GetAllAsAdmin")]
        public IActionResult GetAllAsAdmin(int pageNumber, int pageSize, int licenceId)
        {
            var result = _smsHistoryService.GetAllAsAdmin(pageNumber, pageSize, licenceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
