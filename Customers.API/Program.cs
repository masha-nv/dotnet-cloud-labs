using Customers.API.Data;
using Customers.API.Features.CustomerAddress;
using Customers.API.Features.Customers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddValidation();
builder.Services.AddSqlite<CustomerContext>(connectionString: builder.Configuration.GetConnectionString("CustomersDb"));

var app = builder.Build();

app.AddMigrations().SeedDb();

app.MapCustomersEndpoints();

app.MapCustomerAddressEndpoints();

app.Run();
