using System;
using Customers.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Features.Baskets.GetBaskets;

public static class GetBasketsEndopint
{
    public static void MapGetBasketsEndopint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (CustomerContext dbContext) =>
        {
            var baskets = await dbContext.Baskets.Include(b => b.Items).Include(b => b.Customer)
            .Select(
                basket => new GetBasketsDto(
                    basket.Id,
                    basket.Customer!.Name,
                    basket.Items.Select(a => new GetBasketsItemDto(a.Quantity))
            )).ToListAsync();
            return Results.Ok(baskets);
        });
    }
}
