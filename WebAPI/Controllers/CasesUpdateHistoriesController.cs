using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesUpdateHistoriesController : ControllerBase
    {
        private readonly ICasesUpdateHistoryService _casesUpdateHistoryService;

        public CasesUpdateHistoriesController(ICasesUpdateHistoryService casesUpdateHistoryService)
        {
            _casesUpdateHistoryService = casesUpdateHistoryService;
        }

        [HttpGet("GetAllByCaseId")]
        public IActionResult GetAllByCaseId(int skipVal, int takeVal, int caseId)
        {
            var result = _casesUpdateHistoryService.GetAll(skipVal, takeVal, caseId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
