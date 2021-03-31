using Microsoft.Identity.Client;
using System.Threading.Tasks;
using Ums.Domain.Settings;
using Ums.Infrastructure.Azure.Interfaces;

namespace Ums.Infrastructure.Azure.Services
{
    public class TokenManager : ITokenManager
    {
        private readonly AzureAd azureAd;

        public TokenManager(AzureAd azureAd) => this.azureAd = azureAd;

        public async Task<string> AcquireTokenAsync(string resource)
        {
            var app = ConfidentialClientApplicationBuilder
                .Create(azureAd.ClientId)
                .WithTenantId(azureAd.TenantId)
                .WithClientSecret(azureAd.ClientSecret)
                .Build();
            var scopes = new string[] { resource };
            var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
            return result.AccessToken;
        }
    }
}