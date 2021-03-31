using Ums.Application.Exceptions;
using Ums.Application.Features.Users.Queries.GetUserById;
using Ums.Application.Interfaces.Repositories;
using Ums.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ums.Domain.Entities;

namespace Ums.Application.Features.Products.Queries.GetProductById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<User>>
    {
        private readonly IUserRepository userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Response<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id);

            if(user == null)
            {
                throw new ApiException($"User Not Found.");
            }

            return new Response<User>(user);
        }
    }
}