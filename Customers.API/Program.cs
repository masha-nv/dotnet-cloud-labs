using System.Text.Json;
using Customers.API.Data;
using Customers.API.Features.Baskets.Authorization;
using Customers.API.Features.Baskets.UpsertBasket;
using Customers.API.Features.CustomerAddress;
using Customers.API.Features.Customers;
using Customers.API.Shared.Authorization;
using Customers.API.Shared.ErrorHandling;
using Customers.API.Shared.FileUpload;
using Customers.API.Shared.Timing;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddValidation();
builder.Services.AddSqlite<CustomerContext>(connectionString: builder.Configuration.GetConnectionString("CustomersDb"));
builder.Services.AddHealthChecks();
builder.Services.AddHttpLogging();
builder.Services.AddProblemDetails().AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<FileUploadHandler>();


builder.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.MapInboundClaims = false;
                    options.TokenValidationParameters.RoleClaimType = "role";
                });

builder.AddAppAuthorization();
builder.Services.AddSingleton<BasketAuthorizationHandler>();

var app = builder.Build();

app.AddMigrations().SeedDb();

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

app.UseStaticFiles();
app.MapCustomersEndpoints();
app.MapCustomerAddressEndpoints();
app.MapBasketsEndpoints();



app.Run();
