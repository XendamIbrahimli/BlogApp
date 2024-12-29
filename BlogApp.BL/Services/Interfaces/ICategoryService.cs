using BlogApp.BL.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<int> CreateCategory(CategoryCreateDto dto);
    }
}
