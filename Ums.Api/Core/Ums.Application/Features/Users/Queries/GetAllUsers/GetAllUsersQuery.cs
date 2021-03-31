using Ums.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using Ums.Domain.Entities;

namespace Ums.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<Response<IEnumerable<User>>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}