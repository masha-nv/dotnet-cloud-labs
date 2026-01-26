using System;
using Customers.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Features.Customers.DeleteCustomer;

public static class DeleteCustomerEndpoint
{
    public static void MapDeleteCustomerEndpoint(this IEndpointRouteBuilder app)
    {

        app.MapDelete("/{id}", ([FromRoute] Guid id, CustomerData data) =>
        {
            data.DeleteCustomer(id);
            return Results.NoContent();
        });
    }
}
