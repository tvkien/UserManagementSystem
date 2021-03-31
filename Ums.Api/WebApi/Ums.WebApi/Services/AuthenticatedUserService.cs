using Ums.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using Ums.Application.Extensions;

namespace Ums.WebApi.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            var uid = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
            UserId = uid.TryParseGuid();
        }

        public Guid UserId { get; }
    }
}