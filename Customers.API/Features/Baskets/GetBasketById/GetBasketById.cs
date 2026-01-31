using System;
using Microsoft.AspNetCore.Mvc;
using Customers.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Features.Baskets.GetBasketById;

public static class GetBasketById
{
    public static void MapGetBasketById(this IEndpointRouteBuilder app)
    {
        app.MapGet("/{basketId}", async ([FromServices] CustomerContext dbContext, [FromRoute] Guid basketId) =>
        {
            var basket = await dbContext.Baskets.Include(b => b.Customer)
            .Include(b => b.Items)
            .Where(b => b.Id == basketId).FirstOrDefaultAsync();

            if (basket is null)
            {
                return Results.NotFound();
            }

            GetBasketDto getBasketDto = new GetBasketDto(basket.Id, basket.Customer!.Name, basket.Items);
            return Results.Ok(getBasketDto);
        });
    }
}
