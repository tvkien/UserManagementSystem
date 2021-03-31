using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Infrastructure
{
    public class HttpClientBase : IHttpClientBase
    {
        private readonly HttpClient httpClient;

        public HttpClientBase(IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient();
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) 
            => await httpClient.SendAsync(request);
    }
}