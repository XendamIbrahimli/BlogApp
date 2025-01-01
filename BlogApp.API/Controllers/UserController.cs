using BlogApp.BL.DTOs;
using BlogApp.BL.Helpers;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController(IUserRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetByUsername(string username)
        {
            return Ok(await _repo.GetUserByUsernameAsync(username));
        }
        
        
    }
}
