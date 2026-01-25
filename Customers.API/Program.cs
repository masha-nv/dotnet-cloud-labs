using Customers.API.Mappers;
using Customers.API.Models;
using Microsoft.AspNetCore.Mvc;
using Customers.API.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

List<CustomerAddress> addresses = [new CustomerAddress { Country = "USA", State = "CA", Id = Guid.NewGuid() }];

List<Customer> customers = [
    new Customer { GithubUserName = "mashadev", Name = "Masha", Id = Guid.NewGuid(), Address = addresses[0], LastVisit = new DateOnly(2026, 01, 25) }
];

const string GetCustomerByIdEndPoint = "GetCustomerById";

app.MapGet("/api/customers", () => customers.Select(c => c.ToCustomerSummaryDto()));

app.MapGet("/api/customers/{id}", ([FromRoute] Guid id) =>
{
    var customer = customers.Find(c => c.Id == id);
    if (customer is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(customer.ToCustomerDetailsDto());
}).WithName(GetCustomerByIdEndPoint);

app.MapPost("/api/customers", ([FromBody] CreateCustomerDto customer) =>
{
    var address = addresses.Find(a => a.Id == customer.CustomerAddressId);
    Customer c = customer.ToNewCustomer(address!);
    customers.Add(c);
    return Results.CreatedAtRoute(GetCustomerByIdEndPoint, new { id = c.Id }, c.ToCustomerDetailsDto());
});

app.MapPut("/api/customers/{id}", ([FromRoute] Guid id, [FromBody] UpdateCustomerDto customer) =>
{
    var idx = customers.FindIndex(c => c.Id == id);
    var address = addresses.Find(a => a.Id == customer.CustomerAddressId);
    if (idx == -1)
    {
        return Results.NotFound();
    }
    Customer updated = customer.ToUpdatedCustomer(address!);
    customers[idx] = updated;
    return Results.NoContent();
});

app.MapDelete("/api/customers/{id}", ([FromRoute] Guid id) =>
{
    customers.RemoveAll(c => c.Id == id);
    return Results.NoContent();
});


app.MapGet("/api/customers/addresses", () => addresses);



app.Run();
