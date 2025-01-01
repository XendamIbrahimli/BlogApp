using BlogApp.BL.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Validators
{
    public class LoginDtoValidator:AbstractValidator<LoginDto>
    {
        public LoginDtoValidator() 
        {
            RuleFor(x=>x.UsernameOrEmail)
                .NotEmpty()
                .NotNull();
            RuleFor(x=>x.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
