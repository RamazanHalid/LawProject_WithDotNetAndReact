using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.DTOs.CasesDocumentDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesDocumentsController : ControllerBase
    {
        private ICasesDocumentService _casesDocumentService;

        public CasesDocumentsController(ICasesDocumentService casesDocumentService)
        {
            _casesDocumentService = casesDocumentService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _casesDocumentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _casesDocumentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(CasesDocumentAddDto casesDocumentAddDto)
        { 
            var result = _casesDocumentService.Add(casesDocumentAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CasesDocumentUpdateDto casesDocumentUpdateDto)
        {
            var result = _casesDocumentService.Update(casesDocumentUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _casesDocumentService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
