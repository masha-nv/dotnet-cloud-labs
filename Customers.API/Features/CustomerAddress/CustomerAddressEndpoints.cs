using System;

namespace Customers.API.Features.CustomerAddress;

public static class CustomerAddressEndpoints
{
    public static void MapCustomerAddressEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/customers/addresses");
        group.MapGetCustomerAddresses();
    }
}
