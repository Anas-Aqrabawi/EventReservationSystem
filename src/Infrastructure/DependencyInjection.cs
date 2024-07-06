using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SampleProject.Application.Common.Interfaces;
using SampleProject.Application.IRepositries;
using SampleProject.Application.IServices;
using SampleProject.Domain.Constants;
using SampleProject.Domain.Entities;
using SampleProject.Infrastructure.Authentication;
using SampleProject.Infrastructure.Data;
using SampleProject.Infrastructure.Data.Interceptors;
using SampleProject.Infrastructure.Repositires;
using SampleProject.Infrastructure.Services;
using SampleProject.Infrastructure.Common;
using SampleProject.Core.Entities;
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("EventReservationCS");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<IWeatherforcastService, WeatherforcastService>();
        services.AddScoped<IWeatherforcastRepositry, WeatherforcastRepositry>();
        services.AddScoped<IDbContext, DbContext>();

        services.AddSingleton(TimeProvider.System);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        services.AddAuthenticationServices(configuration);
        return services;
    }
    public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.jwtSettings, jwtSettings);
        services.AddSingleton(Options.Options.Create(jwtSettings));
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),


            };

        });

        return services;
    }
}
