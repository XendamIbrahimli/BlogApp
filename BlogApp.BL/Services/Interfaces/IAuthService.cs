using BlogApp.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginDto dto);
        Task RegisterAsync(RegisterDto dto);
    }
}
