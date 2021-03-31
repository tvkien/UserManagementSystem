using System;
using Ums.Domain.Common;
using Ums.Domain.Enums;

namespace Ums.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public UserStatus Status { get; set; }

        public Guid AzureId { get; set; }
    }
}