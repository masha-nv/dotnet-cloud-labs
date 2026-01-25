using System;

namespace Customers.API.Models;

public class CustomerAddress
{
    public required string Country { get; set; }
    public string? State { get; set; }

    public Guid Id { get; set; }

}
