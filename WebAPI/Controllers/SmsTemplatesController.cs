using Business.Abstract;
using Entities.DTOs.SmsTemplateDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsTemplatesController : ControllerBase
    {
        private ISmsTemplateService _smsTemplateService;

        public SmsTemplatesController(ISmsTemplateService smsTemplateService)
        {
            _smsTemplateService = smsTemplateService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _smsTemplateService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _smsTemplateService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _smsTemplateService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(SmsTemplateAddDto smsTemplateType)
        {
            var result = _smsTemplateService.Add(smsTemplateType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(SmsTemplateUpdateDto smsTemplateType)
        {
            var result = _smsTemplateService.Update(smsTemplateType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
