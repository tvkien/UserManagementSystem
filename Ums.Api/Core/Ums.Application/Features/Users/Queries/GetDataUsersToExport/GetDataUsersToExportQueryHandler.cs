using AutoMapper;
using Ums.Application.Features.Users.Queries.GetDataUsersToExport.Response;
using Ums.Application.Interfaces.Repositories;
using Ums.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Ums.Domain.Entities;

namespace Ums.Application.Features.Users.Queries.GetDataUsersToExport
{
    public class GetDataUsersToExportQueryHandler : IRequestHandler<GetDataUsersToExportQuery, Response<DataUsers>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetDataUsersToExportQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<Response<DataUsers>> Handle(
            GetDataUsersToExportQuery request, 
            CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();
            var usersExport = mapper.Map<List<User>, List<UserExport>>((List<User>)users);
            var dataUsers = new DataUsers
            {
                Data = usersExport,
                Headers = new UserExport().GetHeader()
            };

            return new Response<DataUsers>(dataUsers);
        }
    }
}