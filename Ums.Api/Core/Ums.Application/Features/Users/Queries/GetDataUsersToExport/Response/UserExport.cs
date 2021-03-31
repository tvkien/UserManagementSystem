using System.Collections.Generic;

namespace Ums.Application.Features.Users.Queries.GetDataUsersToExport.Response
{
    public class UserExport
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<Header> GetHeader() =>
            new List<Header>
            {
                new Header
                {
                    Key = "firstName",
                    Label = "First Name"
                },
                new Header
                {
                    Key = "lastName",
                    Label = "Last Name"
                },
                new Header
                {
                    Key = "email",
                    Label = "Email"
                }
            };
    }
}