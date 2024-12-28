using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Context
{
    public class BlogDbContext :DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
    }
}
