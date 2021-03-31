using System.Threading.Tasks;
using Ums.Domain.Entities;

namespace Ums.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<bool> IsEmailExistAsync(string email);
    }
}