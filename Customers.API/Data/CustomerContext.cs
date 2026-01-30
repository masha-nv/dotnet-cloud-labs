using System;
using Customers.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Data;

public class CustomerContext(DbContextOptions<CustomerContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerAddress> CustomerAddresses => Set<CustomerAddress>();

    public DbSet<CustomerBusket> Buskets => Set<CustomerBusket>();
    public DbSet<BusketItem> Items => Set<BusketItem>();
}
