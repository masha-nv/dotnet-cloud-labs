using System;
using Customers.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Features.CustomerAddress;

public static class GetCustomerAddresses
{
    public static void MapGetCustomerAddresses(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (CustomerContext context) =>
        {
            return await context.CustomerAddresses.ToListAsync();
        });
    }
}
