using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryRepository _repo) : ControllerBase
    {
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetAll().ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            await _repo.AddAsync(category);
            await _repo.SaveAsync();
            return Ok(category.Id);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _repo.GetByIdAsync(Id));
        }
        //[HttpGet("GetByMethod")]
        //public async Task<IActionResult> GetWhere()
        //{
        //    return Ok();
        //}
        [HttpGet("IsExist")]
        public async Task<IActionResult> IsExistAsync(int id)
        {
            return Ok(await _repo.IsExistAsync(id));
        }


    }
}
