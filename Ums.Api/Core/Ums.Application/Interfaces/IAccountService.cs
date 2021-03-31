using System.Threading.Tasks;
using Ums.Domain;

namespace Ums.Application.Interfaces
{
    public interface IAccountService
    {
        Task<UserB2BInvitation> InviteClientAsync(UserB2BInvitation user);
    }
}