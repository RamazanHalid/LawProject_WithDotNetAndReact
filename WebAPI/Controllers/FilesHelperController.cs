using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesHelperController : ControllerBase
    {



        [HttpPost("AddFileForCaseDocuments")]
        public IActionResult AddFileForCaseDocuments(IFormFile myFile)
        {
            var result = FileHelper.Add(myFile, "CasesDocuments");
            return Ok(result);
        }
        [HttpPost("AddUserProfileImage")]
        public IActionResult AddProfileImage(IFormFile myFile)
        {
            var result = FileHelper.Add(myFile, "UserProfileImages");
            return Ok(result);
        }
        [HttpPost("AddLicenceProfileImage")]
        public IActionResult AddLicenceProfileImage(IFormFile myFile)
        {
            var result = FileHelper.Add(myFile, "LicenceImages");
            return Ok(result);
        }
    }
}
