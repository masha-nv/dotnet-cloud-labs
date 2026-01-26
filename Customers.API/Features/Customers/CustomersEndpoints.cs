using System;
using Customers.API.Features.Customers.CreateCustomer;
using Customers.API.Features.Customers.DeleteCustomer;
using Customers.API.Features.Customers.GetCustomerById;
using Customers.API.Features.Customers.GetCustomers;
using Customers.API.Features.Customers.UpdateCustomer;

namespace Customers.API.Features.Customers;

public static class CustomersEndpoints
{
    public static void MapCustomersEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/customers");
        group.MapGetCustomersEndpoint();
        group.MapGetCustomerByIdEndpoint();
        group.MapCreateCustomerEndpoint();
        group.MapUpdateCustomerEndpoint();
        group.MapDeleteCustomerEndpoint();
    }
}
