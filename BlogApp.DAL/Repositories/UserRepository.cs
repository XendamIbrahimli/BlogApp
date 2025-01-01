using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using BlogApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        readonly BlogDbContext _context;
        public UserRepository(BlogDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FindAsync(username);
            
        }
    }
}
