using System;
using Customers.API.Data;
using Customers.API.Features.Customer.GetCustomers;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Features.Customers.GetCustomers;

public static class GetCustomersEndpoint
{
    public static void MapGetCustomersEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (CustomerContext dbContext, [AsParameters] GetCustomersDto request) =>
        {
            var skip = (request.Page - 1) * request.PageSize;
            var filteredCustomers = dbContext.Customers.Where(c => string.IsNullOrWhiteSpace(request.Query) || EF.Functions.Like(c.Name, $"%{request.Query}%"));
            return await filteredCustomers.AsNoTracking()
            .OrderBy(c => c.Name)
            .Skip(skip)
            .Take(request.PageSize)
            .Include(c => c.Address).Select(c => c.ToCustomerSummaryDto()).ToListAsync();
        });
    }
}