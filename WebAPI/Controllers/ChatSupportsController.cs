using Business.Abstract;
using Entities.DTOs.ChatSupportDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatSupportsController : ControllerBase
    {

        private readonly IChatSupportService _chatSupportService;

        public ChatSupportsController(IChatSupportService chatSupportService)
        {
            _chatSupportService = chatSupportService;
        }

        [HttpGet("GetAllMessegaAsUser")]
        public IActionResult GetAllMessegaAsUser()
        {
            var result = _chatSupportService.GetAllMessageAsUser();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddMessegaAsUser")]
        public IActionResult AddMessegaAsUser(ChatSupportAddAsUser chatSupportAddAsUser)
        {
            var result = _chatSupportService.AddAsUser(chatSupportAddAsUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddMessegaAsAdmin")]
        public IActionResult AddMessegaAsAdmin(ChatSupportAddAsAdmin chatSupportAddAsAdmin)
        {
            var result = _chatSupportService.AddAsAdmin(chatSupportAddAsAdmin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("MakeItReadAsUser")]
        public IActionResult MakeItReadAsUser()
        {
            var result = _chatSupportService.MakeItReadAsuser();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("MakeItReadAsAdmin")]
        public IActionResult MakeItReadAsAdmin(int userId,int licenceId)
        {
            var result = _chatSupportService.MakeItReadAsAdmin(userId,licenceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ListUsersToSideBar")]
        public IActionResult ListUsersToSideBar()
        {
            var result = _chatSupportService.ListAllUsersToSideBar();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllMessegaAsAdmin")]
        public IActionResult GetAllMessegaAsAdmin(int userId, int licenceId)
        {
            var result = _chatSupportService.GetAllSelectedUserMessageAsAdmin(userId,licenceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
