using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Registrations
{
    public static class FluentValidationRegistration
    {
        public static void AddFluentValidation(this IServiceCollection services) 
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(typeof(FluentValidationRegistration));
        }
    }
}
