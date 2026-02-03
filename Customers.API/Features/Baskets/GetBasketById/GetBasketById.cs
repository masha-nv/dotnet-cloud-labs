using System;
using Microsoft.AspNetCore.Mvc;
using Customers.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Customers.API.Features.Baskets.Authorization;
using System.Security.Claims;

namespace Customers.API.Features.Baskets.GetBasketById;

public static class GetBasketByIdEndpoint
{
    public static void MapGetBasketByIdEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/{basketId}", async ([FromServices] CustomerContext dbContext,
        [FromRoute] Guid basketId,
        [FromServices] IAuthorizationService authorizationService, ClaimsPrincipal user) =>
        {
            var basket = await dbContext.Baskets.Include(b => b.Customer)
            .Include(b => b.Items)
            .Where(b => b.Id == basketId).FirstOrDefaultAsync();

            if (basket is null)
            {
                return Results.NotFound();
            }

            var result = await authorizationService.AuthorizeAsync(user, basket, new IsOwnerOrAdmin { });

            if (!result.Succeeded)
            {
                return Results.Forbid();
            }

            GetBasketDto getBasketDto = new GetBasketDto(basket.Id, basket.Customer!.Name, basket.Items);
            return Results.Ok(getBasketDto);
        });
    }
}
