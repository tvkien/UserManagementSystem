using FrontEnd.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using System;
using System.Threading.Tasks;

namespace FrontEnd.Extensions
{
    public static class AuthenticationExtension
    {
        private static readonly string CustomApiScheme = "CustomApiScheme";

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton(provider => Configuration.GetSection("CookieSetting").Get<CookieSetting>());
            var cookieSetting = services.BuildServiceProvider().GetService<CookieSetting>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CustomApiScheme;
                options.DefaultSignInScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddScheme<AuthenticationSchemeOptions, CustomApiAuthenticationHandler>(CustomApiScheme, options => { })
            .AddMicrosoftIdentityWebApp(options => 
            {
                Configuration.Bind("AzureAd", options);
                options.Events = new OpenIdConnectEvents
                {
                    OnTokenResponseReceived = OnTokenResponseReceived
                };
            },  cookieScheme: cookieSetting.CookieName)
            .EnableTokenAcquisitionToCallDownstreamApi(options =>
            {
                    Configuration.Bind("AzureAd", options);
            }, new string[] { "openid" })
            .AddInMemoryTokenCaches();

            services.Configure<CookieAuthenticationOptions>(cookieSetting.CookieName, options =>
            {
                options.Cookie.HttpOnly = false;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Lax;
                //options.Cookie.MaxAge = new TimeSpan(7, 0, 0, 0);
                //options.Cookie.Expiration = TimeSpan.FromMinutes(cookieSetting.CookieExpiration);
                options.ExpireTimeSpan = TimeSpan.FromMinutes(cookieSetting.CookieExpiration);
                options.SlidingExpiration = false;
            });
        }

        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);
            return model;
        }

        public static async Task OnTokenResponseReceived(TokenResponseReceivedContext context)
        {
            if (context.TokenEndpointResponse?.IdToken != null)
            {
                try
                {
                    var idtoken = context.TokenEndpointResponse.IdToken;

                    var app = ConfidentialClientApplicationBuilder
                    .Create("408265f7-bc76-4e92-aadc-57da299f2e67")
                    .WithTenantId("a767d94a-c314-4b42-a484-da44a9cbd277")
                    .WithClientSecret("P5Bi.GEP8.g_2zOdK-P.H6ykH01q5f85pK")
                    .Build();
                    //var scopes = new string[] { "api://a9bd8516-7d86-45e1-8a0b-f79fd8b1c3a3/.default" };
                    var scopes = new string[] { "a9bd8516-7d86-45e1-8a0b-f79fd8b1c3a3" };
                    var userAssertion = new UserAssertion(idtoken);
                    var result = await app.AcquireTokenOnBehalfOf(scopes, userAssertion).ExecuteAsync();
                    var abc = result.AccessToken;
                }
                catch(Exception ex)
                {

                }
                
            }
        }
    }
}