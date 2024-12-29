using BlogApp.BL.DTOs.Category;
using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService _service):ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            return Ok(await _service.CreateCategory(dto));
        }
        
    }
}
