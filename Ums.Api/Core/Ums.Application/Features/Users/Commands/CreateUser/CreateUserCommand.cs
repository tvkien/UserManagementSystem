using Ums.Application.Wrappers;
using MediatR;
using System;

namespace Ums.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Response<Guid>>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RedirectUrl { get; set; }
    }
}