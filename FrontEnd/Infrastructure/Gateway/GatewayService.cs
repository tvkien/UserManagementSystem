using FrontEnd.Extensions;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Web;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FrontEnd.Infrastructure.Gateway
{
    public class GatewayService : IGatewayService
    {
        private readonly ApiResources apiResources;
        private readonly HttpContext httpContext;
        private readonly IHttpClientBase httpClientBase;
        private readonly ITokenAcquisition tokenAcquisition;

        public GatewayService(
            ApiResources apiResources,
            IHttpContextAccessor httpContextAccessor,
            IHttpClientBase httpClientBase,
            ITokenAcquisition tokenAcquisition)
        {
            this.apiResources = apiResources;
            this.httpContext = httpContextAccessor.HttpContext;
            this.httpClientBase = httpClientBase;
            this.tokenAcquisition = tokenAcquisition;
        }

        public Task<string> BuildUrlAsync(string apiName, string endpoint)
        {
            var resource = apiResources.Resources.FirstOrDefault(x => x.ApiName.ToString().ToUpper() == apiName.ToUpper());
            var url = resource.Uri + endpoint + httpContext.Request.QueryString.Value;
            return Task.FromResult(url);
        }

        public async Task<T> RequestAsync<T>(string apiName, string url)
        {
            var resource = apiResources.Resources.FirstOrDefault(x => x.ApiName.ToString().ToUpper() == apiName.ToUpper());
            var accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(resource.Scopes);
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = new HttpMethod(httpContext.Request.Method),
                Content = await httpContext.GetContentAsync()
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await httpClientBase.SendAsync(request);
            return await response.Content.ReadAsAsync<T>();
        }
    }
}