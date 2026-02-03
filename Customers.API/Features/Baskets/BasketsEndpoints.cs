using System;
using Customers.API.Features.Baskets.GetBasketById;
using Customers.API.Features.Baskets.GetBaskets;

namespace Customers.API.Features.Baskets.UpsertBasket;

public static class BasketsEndpoints
{
    public static void MapBasketsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/baskets");
        group.MapUpsertBasketEndpoint();
        group.MapGetBasketsEndopint();
        group.MapGetBasketByIdEndpoint();
    }
}
