using System;
using System.Diagnostics;
using Customers.API.Data;
using Customers.API.Features.Customers.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace Customers.API.Features.Customers.GetCustomerById;

public static class GetCustomerEndpoint
{
    public static void MapGetCustomerByIdEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", async ([FromRoute] Guid id, CustomerContext dbContext, ILogger<Program> logger) =>
        {
            Models.Customer? customer = await FindCustomerAsync(id, dbContext);
            if (customer is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(customer);
        }).WithName(RouteNames.GetCustomerByIdEndPoint);
    }

    private static async Task<Models.Customer?> FindCustomerAsync(Guid id, CustomerContext dbContext)
    {
        // throw new SqliteException("Something went wrong", 14);
        return await dbContext.Customers.FindAsync(id);
    }
}
