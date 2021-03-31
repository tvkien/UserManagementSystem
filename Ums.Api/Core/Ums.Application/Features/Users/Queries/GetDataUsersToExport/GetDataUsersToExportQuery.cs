using Ums.Application.Features.Users.Queries.GetDataUsersToExport.Response;
using Ums.Application.Wrappers;
using MediatR;

namespace Ums.Application.Features.Users.Queries.GetDataUsersToExport
{
    public class GetDataUsersToExportQuery : IRequest<Response<DataUsers>>
    {
    }
}