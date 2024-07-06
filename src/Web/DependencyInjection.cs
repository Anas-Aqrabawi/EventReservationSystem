using Azure.Identity;
using SampleProject.Application.Common.Interfaces;
using SampleProject.Infrastructure.Data;
using SampleProject.Web.Services;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Web.Mapping.Config;
using SampleProject.Infrastructure.Common;
using SampleProject.Core.Entities;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddRazorPages();

      

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddEndpointsApiExplorer();

        services.AddOpenApiDocument((configure, sp) =>
        {
            configure.Title = "EventReservations API";
            //define naming of method in nswag generated client
            configure.OperationProcessors.Add(new FlattenOperationsProcessor());

        });

        services.AddMapping();

        return services;
    }

    public static IServiceCollection AddKeyVaultIfConfigured(this IServiceCollection services, ConfigurationManager configuration)
    {
        var keyVaultUri = configuration["KeyVaultUri"];
        if (!string.IsNullOrWhiteSpace(keyVaultUri))
        {
            configuration.AddAzureKeyVault(
                new Uri(keyVaultUri),
                new DefaultAzureCredential());
        }

        return services;
    }
}
