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
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements
{
    public class AuthService(IUserRepository _repo, IMapper _mapper) : IAuthService
    {
        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user=await _repo.GetAll().Where(x=>x.Username==dto.UsernameOrEmail || x.Email==dto.UsernameOrEmail).FirstOrDefaultAsync();
            if (user == null)
                throw new NotFoundException<User>();
            else if (!HashHelper.VerifyHashedPassword(user.PasswordHash, dto.Password))
                throw new NotFoundException("Password or usernmae is wrong");

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("Fullname", user.Fullname)
            };

            SymmetricSecurityKey key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7f187014-2a9d-46cb-b8b4-a0d9011cb6ee"));

            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSec = new JwtSecurityToken(
                issuer: "https://localhost:7252",
                audience: "https://localhost:7252",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(50),
                signingCredentials: cred
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSec);

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
