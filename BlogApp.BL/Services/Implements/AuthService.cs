using AutoMapper;
using BlogApp.BL.DTOs;
using BlogApp.BL.Exceptions;
using BlogApp.BL.Exceptions.NotFoundExceptionWithType;
using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements
{
    public class AuthService(IUserRepository _repo, IMapper _mapper) : IAuthService
    {
        public async Task<bool> LoginAsync(LoginDto dto)
        {
            var user=await _repo.GetAll().Where(x=>x.Username==dto.UsernameOrEmail || x.Email==dto.UsernameOrEmail).FirstOrDefaultAsync();
            if(user==null) 
                throw new NotFoundException<User>();
            return HashHelper.VerifyHashedPassword(user.PasswordHash, dto.Password);
            
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var user=await _repo.GetAll().Where(x=>x.Username==dto.Username || x.Email==dto.Email).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.Username == dto.Username)
                    throw new ExistException("This Username already was used by another user ");
                else if (user.Email == dto.Email)
                    throw new ExistException("This Email already was used by another user");
            }
            await _repo.AddAsync(_mapper.Map<User>(dto));
            await _repo.SaveAsync();
        }
    }
}
