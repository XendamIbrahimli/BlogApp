using BlogApp.BL.DTOs;
using BlogApp.BL.Exceptions;
using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
            try
            {
                return Ok(await _service.LoginAsync(dto));

            }
            catch (Exception ex)
            {
                if (ex is IBaseException Bex)
                {
                    return StatusCode(Bex.StatusCode, new
                    {
                        StatusCode = Bex.StatusCode,
                        Message = Bex.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        ex.Message
                    });
                }
            }
        }
    }
}
