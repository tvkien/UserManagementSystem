using Ums.Application.Wrappers;
using MediatR;
using System;

namespace Ums.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}