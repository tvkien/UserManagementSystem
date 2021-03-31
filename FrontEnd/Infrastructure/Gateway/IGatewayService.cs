using FrontEnd.Models;
using System.Threading.Tasks;

namespace FrontEnd.Infrastructure.Gateway
{
    public interface IGatewayService
    {
        Task<T> RequestAsync<T>(string apiName, string url);

        Task<string> BuildUrlAsync(string apiName, string endpoint);
    }
}