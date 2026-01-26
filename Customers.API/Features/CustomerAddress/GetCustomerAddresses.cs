using System;
using Customers.API.Data;

namespace Customers.API.Features.CustomerAddress;

public static class GetCustomerAddresses
{
    public static void MapGetCustomerAddresses(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/customers/addresses", (CustomerData data) => data.GetCustomerAddresses());
    }
}
