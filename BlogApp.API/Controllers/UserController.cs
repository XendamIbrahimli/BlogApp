using BlogApp.BL.Helpers;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository _repo) : ControllerBase
    {
        [HttpGet("ByUsername")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            return Ok(await _repo.GetUserByUsernameAsync(username));
        }
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            await _repo.AddAsync(user);
            return Ok();
        }
        [HttpGet("Hash")]
        public async Task<IActionResult> Hash(string password)
        {
            return Ok(HashHelper.HashPassword(password));
        }
        [HttpGet("IsCorrectHash")]
        public async Task<IActionResult> IsCorrect(string hashpassword ,string password)
        {
            return Ok(HashHelper.VerifyHashedPassword(hashpassword,password));
        }
    }
}
