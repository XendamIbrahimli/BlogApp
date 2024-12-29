using AutoMapper;
using BlogApp.BL.DTOs.Category;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implemenets.Profiles
{  
    public class CategoryProfile:Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryCreateDto, Category>();
        }
    }
}
