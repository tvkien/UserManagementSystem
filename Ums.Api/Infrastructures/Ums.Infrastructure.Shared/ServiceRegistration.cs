using Ums.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ums.Domain.Settings;
using Ums.Infrastructure.Shared.Services;

namespace Ums.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(provider => config.GetSection("MailSettings").Get<MailSettings>());
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}