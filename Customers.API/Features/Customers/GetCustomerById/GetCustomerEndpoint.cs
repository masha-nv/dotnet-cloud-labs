using System;
using Customers.API.Data;
using Customers.API.Features.Customers.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Features.Customers.GetCustomerById;

public static class GetCustomerEndpoint
{
    public static void MapGetCustomerByIdEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/customers/{id}", ([FromRoute] Guid id, CustomerData data) =>
{
    CustomerDetailsDto? customer;
    try
    {
        customer = data.GetCustomer(id);
    }
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
    return Results.Ok(customer);
}).WithName(RouteNames.GetCustomerByIdEndPoint);
    }
}
