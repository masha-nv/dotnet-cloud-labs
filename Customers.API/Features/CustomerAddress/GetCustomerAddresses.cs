using System;
using Customers.API.Data;

namespace Customers.API.Features.CustomerAddress;

public static class GetCustomerAddresses
{
    public static void MapGetCustomerAddresses(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", (CustomerData data) => data.GetCustomerAddresses());
    }
}
