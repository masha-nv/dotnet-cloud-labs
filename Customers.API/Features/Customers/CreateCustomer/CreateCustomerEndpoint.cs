using System;
using Customers.API.Data;
using Customers.API.Features.Customers.Constants;
using Customers.API.Features.Customers.GetCustomerById;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Features.Customers.CreateCustomer;

public static class CreateCustomerEndpoint
{
    public static void MapCreateCustomerEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", async ([FromBody] CreateCustomerDto customer, CustomerContext context) =>
        {
            Models.Customer c = customer.ToNewCustomer();
            await context.Customers.AddAsync(c);
            await context.SaveChangesAsync();
            return Results.CreatedAtRoute(RouteNames.GetCustomerByIdEndPoint, new { id = c.Id }, c.ToCustomerDetailsDto());
        });
    }
}
