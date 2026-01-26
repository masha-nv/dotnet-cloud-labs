using Customers.API.Data;
using Customers.API.Features.CustomerAddress;
using Customers.API.Features.Customers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddSingleton<CustomerData>();

var app = builder.Build();

app.MapCustomersEndpoints();

app.MapCustomerAddressEndpoints();

app.Run();
