using AutoMapper;
using BlogApp.BL.DTOs.Category;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implemenets
{
    public class CategoryService(BlogDbContext _context, IMapper _mapper):ICategoryService
    {
        public async Task<int> CreateCategory(CategoryCreateDto dto)
        {
            Category category=_mapper.Map<Category>(dto);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

    }
}
