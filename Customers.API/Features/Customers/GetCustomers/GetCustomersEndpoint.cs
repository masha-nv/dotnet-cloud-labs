using System;
using Customers.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Features.Customers.GetCustomers;

public static class GetCustomersEndpoint
{
    public static void MapGetCustomersEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (CustomerContext dbContext) =>
        {
            return await dbContext.Customers.AsNoTracking().Include(c => c.Address).Select(c => c.ToCustomerSummaryDto()).ToListAsync();
        });
    }
}