using FrontEnd.Extensions;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Infrastructure.Gateway
{
    public class GatewayService : IGatewayService
    {
        private readonly ApiResources apiResources;
        private readonly HttpContext httpContext;
        private readonly IHttpClientBase httpClientBase;

        public GatewayService(
            ApiResources apiResources,
            IHttpContextAccessor httpContextAccessor,
            IHttpClientBase httpClientBase)
        {
            this.apiResources = apiResources;
            this.httpContext = httpContextAccessor.HttpContext;
            this.httpClientBase = httpClientBase;
        }

        public Task<string> BuildUrlAsync(string apiName, string endpoint)
        {
            var resource = apiResources.Resources.FirstOrDefault(x => x.ApiName.ToString().ToUpper() == apiName.ToUpper());
            var url = resource.Uri + endpoint + httpContext.Request.QueryString.Value;
            return Task.FromResult(url);
        }

        public async Task<T> RequestAsync<T>(string url)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = new HttpMethod(httpContext.Request.Method),
                Content = await httpContext.GetContentAsync()
            };
            var response = await httpClientBase.SendAsync(request);
            return await response.Content.ReadAsAsync<T>();
        }
    }
}