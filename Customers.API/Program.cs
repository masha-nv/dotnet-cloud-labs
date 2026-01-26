using Customers.API.Data;
using Customers.API.Features.CustomerAddress;
using Customers.API.Features.Customers.CreateCustomer;
using Customers.API.Features.Customers.DeleteCustomer;
using Customers.API.Features.Customers.GetCustomerById;
using Customers.API.Features.Customers.GetCustomers;
using Customers.API.Features.Customers.UpdateCustomer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddSingleton<CustomerData>();

var app = builder.Build();

app.MapGetCustomersEndpoint();
app.MapGetCustomerByIdEndpoint();
app.MapCreateCustomerEndpoint();
app.MapUpdateCustomerEndpoint();
app.MapDeleteCustomerEndpoint();

app.MapGetCustomerAddresses();

app.Run();
