using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.API.Models;

public class CustomerBusket
{
    public Guid Id { get; set; }
    public Customer? Customer { get; set; }
    [ForeignKey("Customer")]
    public Guid CustomerId { get; set; }

    public List<BusketItem> Items { get; set; } = [];
}
