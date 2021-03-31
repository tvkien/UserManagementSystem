using Ums.Application.Wrappers;
using MediatR;
using System;

namespace Ums.Application.Features.Users.Commands.DeleteUserById
{
    public class DeleteUserByIdCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}