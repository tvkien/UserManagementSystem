using Ums.Application.Wrappers;
using MediatR;
using Ums.Domain.Entities;

namespace Ums.Application.Features.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<Response<User>>
    {
        public string Email { get; set; }
    }
}