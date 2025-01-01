using BlogApp.BL.DTOs;
using BlogApp.Core.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Validators
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
        readonly IUserRepository _repo;
        public RegisterDtoValidator(IUserRepository repo) 
        {
            _repo = repo;
            RuleFor(x=>x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
            RuleFor(x=>x.Username)
                .NotEmpty()
                .NotNull()
                .Must(x=>_repo.GetUserByUsernameAsync(x).Result==null)
                .WithMessage("Username is exist");
        }
    }
}
