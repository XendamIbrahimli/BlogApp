using BlogApp.BL.DTOs;

namespace BlogApp.API.Registrations
{
    public static class JwtOptionsRegistration
    {
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Jwt));
            return services;
        }
    }
}
