using System;

namespace Ums.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        Guid UserId { get; }
    }
}