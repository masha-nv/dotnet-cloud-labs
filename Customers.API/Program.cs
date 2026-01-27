using Customers.API.Data;
using Customers.API.Features.CustomerAddress;
using Customers.API.Features.Customers;
using Customers.API.Shared.Timing;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddValidation();
builder.Services.AddSqlite<CustomerContext>(connectionString: builder.Configuration.GetConnectionString("CustomersDb"));
builder.Services.AddHealthChecks();
builder.Services.AddHttpLogging();

var app = builder.Build();

app.AddMigrations().SeedDb();

app.UseHealthChecks("/api/customers");
app.UseMiddleware<RequestTimingMiddleware>();
app.UseHttpLogging();

app.MapCustomersEndpoints();

app.MapCustomerAddressEndpoints();

app.Run();
