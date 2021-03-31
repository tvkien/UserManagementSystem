using Ums.Application.Wrappers;
using MediatR;
using System;
using Ums.Domain.Entities;

namespace Ums.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<Response<User>>
    {
        public Guid Id { get; set; }
    }
}