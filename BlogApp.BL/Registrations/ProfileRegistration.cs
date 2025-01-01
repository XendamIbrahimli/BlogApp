using BlogApp.BL.Profiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Registrations
{
    public static class ProfileRegistration
    {
        public static void AddAutoMapper(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(ProfileRegistration));
        }
    }
}
