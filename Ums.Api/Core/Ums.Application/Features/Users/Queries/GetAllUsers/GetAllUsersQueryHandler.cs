using Ums.Application.Interfaces.Repositories;
using Ums.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ums.Application.Features.Users.Queries.GetAllUsers;
using Ums.Domain.Entities;

namespace Ums.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<IEnumerable<User>>>
    {
        private readonly IUserRepository userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Response<IEnumerable<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();
            return new Response<IEnumerable<User>>(users);
        }
    }
}