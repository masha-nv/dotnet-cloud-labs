using System.Text.Json;
using Customers.API.Data;
using Customers.API.Features.CustomerAddress;
using Customers.API.Features.Customers;
using Customers.API.Shared.ErrorHandling;
using Customers.API.Shared.Timing;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddValidation();
builder.Services.AddSqlite<CustomerContext>(connectionString: builder.Configuration.GetConnectionString("CustomersDb"));
builder.Services.AddHealthChecks();
builder.Services.AddHttpLogging();
builder.Services.AddProblemDetails().AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.AddMigrations().SeedDb();

app.UseHealthChecks("/api/customers");
app.UseHttpLogging();
app.UseMiddleware<RequestTimingMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler();
}

app.MapCustomersEndpoints();

app.MapCustomerAddressEndpoints();

app.Run();
