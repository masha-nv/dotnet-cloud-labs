using System;

namespace Customers.API.Shared.Authorization;

public static class AuthorizationExtensions
{
    public static IHostApplicationBuilder AddAppAuthorization(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(Policies.UserPolicy, builder => builder.RequireClaim("scope", "customers:read"))
            .AddPolicy(Policies.AdminPolicy, builder =>
            {
                builder.RequireClaim("scope", "customers:read");
                builder.RequireRole(Roles.Admin);
            });
        return builder;
    }
}
