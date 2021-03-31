using Microsoft.Graph;
using System.Net.Http;
using System.Threading.Tasks;
using Ums.Domain.Settings;
using Ums.Infrastructure.Azure.Interfaces;

namespace Ums.Infrastructure.Azure.Services
{
    public class GraphAuthenticationProvider : IAuthenticationProvider
    {
        private readonly ITokenManager tokenManager;
        private readonly AzureAd azureAd;

        public GraphAuthenticationProvider(
            ITokenManager tokenManager,
            AzureAd azureAd)
        {
            this.tokenManager = tokenManager;
            this.azureAd = azureAd;
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var accessToken = await tokenManager.AcquireTokenAsync(azureAd.GraphResource);
            request.Headers.Add("Authorization", "Bearer " + accessToken);
        }
    }
}