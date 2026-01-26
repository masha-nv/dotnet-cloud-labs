using System;
using Customers.API.Data;

namespace Customers.API.Features.Customers.GetCustomers;

public static class GetCustomersEndpoint
{
    public static void MapGetCustomersEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/customers", (CustomerData data) => data.GetCustomers());
    }
}