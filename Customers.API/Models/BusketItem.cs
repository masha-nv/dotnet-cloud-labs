using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.API.Models;

public class BasketItem
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }

    [ForeignKey(name: "CustomerBasket")]
    public Guid CustomerBasketId { get; set; }
}
