using System;
using Customers.API.Data;
using Customers.API.Features.Customers.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Features.Customers.CreateCustomer;

public static class CreateCustomerEndpoint
{
    public static void MapCreateCustomerEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", ([FromBody] CreateCustomerDto customer, CustomerData data) =>
        {
            var createdCustomer = data.CreateCustomer(customer);
            return Results.CreatedAtRoute(RouteNames.GetCustomerByIdEndPoint, new { id = createdCustomer.Id }, createdCustomer);
        });
    }
}
