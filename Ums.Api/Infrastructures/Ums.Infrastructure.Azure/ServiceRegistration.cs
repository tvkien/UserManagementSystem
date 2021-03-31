using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using Ums.Application.Interfaces;
using Ums.Domain.Settings;
using Ums.Infrastructure.Azure.Interfaces;
using Ums.Infrastructure.Azure.Services;

namespace Ums.Infrastructure.Azure
{
    public static class ServiceRegistration
    {
        public static void AddAzureInfrastructure(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddSingleton(provider => config.GetSection("AzureAd").Get<AzureAd>());
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<IAccountService, GraphService>();
            services.AddScoped<IGraphServiceClient, GraphServiceClient>();
            services.AddScoped<IAuthenticationProvider, GraphAuthenticationProvider>();
        }
    }
}