using Ums.Application.Exceptions;
using Ums.Application.Interfaces.Repositories;
using Ums.Application.Wrappers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Ums.Domain.Entities;

namespace Ums.Application.Features.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, Response<User>>
    {
        private readonly IUserRepository userRepository;

        public GetUserByEmailHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Response<User>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                throw new ApiException($"User Not Found.");
            }

            return new Response<User>(user);
        }
    }
}