using System;
using Customers.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Data;

public static class DataExtensions
{
    public static WebApplication AddMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        CustomerContext context = scope.ServiceProvider.GetRequiredService<CustomerContext>();
        context.Database.Migrate();
        return app;
    }

    public static void SeedDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CustomerContext>();

        if (!context.CustomerAddresses.Any())
        {
            context.CustomerAddresses.AddRange([new CustomerAddress { Country = "Russia" }]);
            context.SaveChanges();
        }
    }


}
