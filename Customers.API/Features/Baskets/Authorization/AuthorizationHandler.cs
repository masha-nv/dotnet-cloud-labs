using System;
using System.Security.Claims;
using Customers.API.Models;
using Customers.API.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Customers.API.Features.Baskets.Authorization;

public class BasketAuthorizationHandler : AuthorizationHandler<IsOwnerOrAdmin, CustomerBasket>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsOwnerOrAdmin requirement, CustomerBasket resource)
    {
        var userId = context.User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        if (userId is null || string.IsNullOrEmpty(userId))
        {
            return Task.CompletedTask;
        }

        if (context.User.IsInRole(Roles.Admin))
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}

public class IsOwnerOrAdmin : IAuthorizationRequirement { }
