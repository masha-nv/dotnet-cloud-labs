using System;
using Customers.API.Data;

namespace Customers.API.Features.Customers.GetCustomers;

public static class GetCustomersEndpoint
{
    public static void MapGetCustomersEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", (CustomerData data) => data.GetCustomers());
    }
}