using API_WhitJsonWebToken_JWT_.API.Context;
using API_WhitJsonWebToken_JWT_.API.Customs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API_WhitJsonWebToken_JWT_.API.Services
{
    public static class Services
    {

        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region "Context Config"
            services.AddDbContext<ApiJwtContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("db")));
            #endregion

            #region "JWS Config"
            services.AddSingleton<Utilitys>();
            services.AddAuthentication(configureOptions =>
            {
                configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.RequireHttpsMetadata = false;
                configureOptions.SaveToken = true;
                configureOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]!))
                };
            });
            #endregion
            return services;
        }
    }
}
