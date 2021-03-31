using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using System;
using System.Threading.Tasks;
using Ums.Application.Interfaces;
using Ums.Domain;

namespace Ums.Infrastructure.Azure.Services
{
    public class GraphService : IAccountService
    {
        private readonly IGraphServiceClient graphServiceClient;
        private readonly ILogger<GraphService> logger;
        private readonly string redirectUrl;

        public GraphService(
            IGraphServiceClient graphServiceClient,
            ILogger<GraphService> logger,
            IConfiguration configuration)
        {
            this.graphServiceClient = graphServiceClient;
            this.logger = logger;
            this.redirectUrl = configuration.GetSection("RedirectUrl").Value;
        }

        public async Task<UserB2BInvitation> InviteClientAsync(UserB2BInvitation user)
        {
            logger.LogInformation($"Inviting user B2B email {user.EmailAddress}");

            var invitation = new Invitation
            {
                InvitedUserEmailAddress = user.EmailAddress,
                InvitedUserDisplayName = $"{user.FirstName} {user.LastName}",
                InviteRedirectUrl = user.RedirectUrl ?? redirectUrl,
                SendInvitationMessage = true
            };

            var result = await graphServiceClient.Invitations.Request().AddAsync(invitation);
            logger.LogInformation($"Invited user B2B email {user.EmailAddress}");

            user.AzureId = Guid.Parse(result.InvitedUser.Id);
            user.InviteRedeemUrl = result.InviteRedeemUrl;
            return user;
        }
    }
}