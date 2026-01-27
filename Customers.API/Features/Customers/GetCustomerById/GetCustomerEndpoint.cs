using System;
using Customers.API.Data;
using Customers.API.Features.Customers.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Features.Customers.GetCustomerById;

public static class GetCustomerEndpoint
{
    public static void MapGetCustomerByIdEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", async ([FromRoute] Guid id, CustomerContext dbContext) =>
{
    var customer = await dbContext.Customers.FindAsync(id);
    if (customer is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(customer);
}).WithName(RouteNames.GetCustomerByIdEndPoint);
    }
}
