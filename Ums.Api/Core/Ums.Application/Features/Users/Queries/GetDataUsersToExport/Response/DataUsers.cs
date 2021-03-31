using System.Collections.Generic;

namespace Ums.Application.Features.Users.Queries.GetDataUsersToExport.Response
{
    public class DataUsers
    {
        public IReadOnlyList<Header> Headers { get; set; }
        public IReadOnlyList<UserExport> Data { get; set; }
    }
}