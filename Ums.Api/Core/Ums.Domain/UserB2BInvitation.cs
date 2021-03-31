using System;

namespace Ums.Domain
{
    public class UserB2BInvitation
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string RedirectUrl { get; set; }

        public string InviteRedeemUrl { get; set; }

        public Guid AzureId { get; set; }
    }
}