using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.API.Models;

public class CustomerBasket
{
    public Guid Id { get; set; }
    public Customer? Customer { get; set; }
    [ForeignKey("Customer")]
    public Guid CustomerId { get; set; }

    public List<BasketItem> Items { get; set; } = [];
}
