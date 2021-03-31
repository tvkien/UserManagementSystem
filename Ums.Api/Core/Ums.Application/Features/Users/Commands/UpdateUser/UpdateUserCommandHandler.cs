using Ums.Application.Exceptions;
using Ums.Application.Features.Users.Commands.UpdateUser;
using Ums.Application.Interfaces.Repositories;
using Ums.Application.Wrappers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ums.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<Guid>>
    {
        private readonly IUserRepository userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new ApiException($"User Not Found.");
            }

            if (user.Email == request.Email)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                await userRepository.UpdateAsync(user);
                return new Response<Guid>(user.Id);
            }

            var isEmailExist = await userRepository.IsEmailExistAsync(request.Email);

            if (isEmailExist)
            {
                throw new ApiException($"User Email already exist in the system.");
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            await userRepository.UpdateAsync(user);
            return new Response<Guid>(user.Id);
        }
    }
}