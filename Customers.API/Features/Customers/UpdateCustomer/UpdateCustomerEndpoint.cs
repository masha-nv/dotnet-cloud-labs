using System;
using Customers.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Features.Customers.UpdateCustomer;

public static class UpdateCustomerEndpoint
{
    public static void MapUpdateCustomerEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/api/customers/{id}", ([FromRoute] Guid id, [FromBody] UpdateCustomerDto customer, CustomerData data) =>
{
    try
    {
        data.UpdateCustomer(id, customer);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});
    }
}
