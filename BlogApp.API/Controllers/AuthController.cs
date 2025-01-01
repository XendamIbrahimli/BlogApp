using BlogApp.BL.DTOs;
using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IAuthService _service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _service.RegisterAsync(dto);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(await _service.LoginAsync(dto));
        } 
    }
}
