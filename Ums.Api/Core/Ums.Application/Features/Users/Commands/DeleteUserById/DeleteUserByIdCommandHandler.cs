using Ums.Application.Exceptions;
using Ums.Application.Interfaces.Repositories;
using Ums.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ums.Application.Features.Users.Commands.DeleteUserById
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Response<bool>>
    {
        private readonly IUserRepository userRepository;

        public DeleteUserByIdCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Response<bool>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id);

            if(user == null)
            {
                throw new ApiException($"User Not Found.");
            }

            await userRepository.DeleteAsync(user);
            return new Response<bool>(true);
        }
    }
}