using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Infrastructure
{
    public interface IHttpClientBase
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}