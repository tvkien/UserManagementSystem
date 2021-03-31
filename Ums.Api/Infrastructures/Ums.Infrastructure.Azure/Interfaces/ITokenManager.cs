using System.Threading.Tasks;

namespace Ums.Infrastructure.Azure.Interfaces
{
    public interface ITokenManager
    {
        Task<string> AcquireTokenAsync(string resource);
    }
}