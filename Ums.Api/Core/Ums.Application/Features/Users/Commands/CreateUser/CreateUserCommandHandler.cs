using AutoMapper;
using Ums.Application.Exceptions;
using Ums.Application.Interfaces.Repositories;
using Ums.Application.Wrappers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Ums.Domain.Entities;
using Ums.Application.Interfaces;
using Ums.Domain;
using Ums.Domain.Enums;

namespace Ums.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<Guid>>
    {
        private readonly IUserRepository userRepository;
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(
            IUserRepository userRepository, 
            IMapper mapper, 
            IAccountService accountService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.accountService = accountService;
        }

        public async Task<Response<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExisting = await userRepository.GetUserByEmailAsync(request.Email);

            if(userExisting != null)
            {
                throw new ApiException($"The user email {request.Email} already existed.");
            }

            var userB2BInvited = await accountService.InviteClientAsync(new UserB2BInvitation
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.Email,
                RedirectUrl = request.RedirectUrl
            });

            var user = mapper.Map<User>(request);
            user.Id = Guid.NewGuid();
            user.AzureId = userB2BInvited.AzureId;
            user.Status = UserStatus.Pending;

            await userRepository.AddAsync(user);
            return new Response<Guid>(user.Id);
        }
    }
}