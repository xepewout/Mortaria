using Microsoft.AspNetCore.Authorization;

namespace Mortaria.Authorization
{
    public class SubscriptionHandler : AuthorizationHandler<SubscriptionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubscriptionRequirement requirement)
        {
            // TODO: Implement your logic to check if the user has an active subscription.
            // If the user has an active subscription, call context.Succeed(requirement).
            // Otherwise, do not call context.Succeed(requirement) and the authorization will fail.

            return Task.CompletedTask;
        }
    }
}
