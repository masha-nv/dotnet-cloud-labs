using System;
using Customers.API.Features.Baskets;
using Customers.API.Data;
using Microsoft.EntityFrameworkCore;
using Customers.API.Models;

namespace Customers.API.Features.Baskets.UpsertBasket;

public static class UpsertBasketEndpoint
{
    public static void MapUpsertBasketEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/{userId}", async (
            Guid userId,
            UpsertBasketDto upsertBasketDto,
            CustomerContext dbContext
            ) =>
        {
            var basket = await dbContext.Baskets.Include(b => b.Items).FirstOrDefaultAsync(b => b.CustomerId == userId);

            if (basket is null)
            {
                basket = new CustomerBasket
                {
                    CustomerId = userId
                };

            }

            basket.Items = upsertBasketDto.Items.Select(i => new BasketItem
            {
                Quantity = i.Quantity,
            }).ToList();

            dbContext.Baskets.Update(basket);
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
