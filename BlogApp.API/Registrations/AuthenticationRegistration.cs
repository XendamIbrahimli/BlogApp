using BlogApp.BL.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogApp.API.Registrations
{
    public static class AuthenticationRegistration
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            JwtOptions JwtOpt = new JwtOptions();
            JwtOpt.Issuer = configuration.GetSection("JwtOptions")["Issuer"]!;
            JwtOpt.Audience = configuration.GetSection("JwtOptions")["Audience"]!;
            JwtOpt.SecretKey = configuration.GetSection("JwtOptions")["SecretKey"]!;

            var signInKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOpt.SecretKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signInKey,
                    ValidAudience = JwtOpt.Audience,
                    ValidIssuer = JwtOpt.Issuer,
                    ClockSkew = TimeSpan.Zero
                };
            });
            return services;

        }

    }
}
