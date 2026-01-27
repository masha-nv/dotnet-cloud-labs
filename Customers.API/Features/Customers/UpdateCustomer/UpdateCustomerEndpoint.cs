using System;
using Customers.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Features.Customers.UpdateCustomer;

public static class UpdateCustomerEndpoint
{
    public static void MapUpdateCustomerEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", async ([FromRoute] Guid id, [FromBody] UpdateCustomerDto customer, CustomerContext dbContext) =>
        {
            var found = await dbContext.Customers.FindAsync(id);
            if (found is null)
            {
                return Results.NotFound();
            }
            found.CustomerAddressId = customer.CustomerAddressId;
            found.GithubUserName = customer.GithubUserName;
            found.Name = customer.Name;
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
