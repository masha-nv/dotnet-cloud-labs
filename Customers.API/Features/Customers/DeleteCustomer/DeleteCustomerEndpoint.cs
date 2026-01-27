using System;
using Customers.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Features.Customers.DeleteCustomer;

public static class DeleteCustomerEndpoint
{
    public static void MapDeleteCustomerEndpoint(this IEndpointRouteBuilder app)
    {

        app.MapDelete("/{id}", async ([FromRoute] Guid id, CustomerContext dbContext) =>
        {
            await dbContext.CustomerAddresses.Where(c => c.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });
    }
}
