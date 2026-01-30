using System;

namespace Customers.API.Models;

public class BusketItem
{
    public Guid Id { get; set; }
    public int MyProperty { get; set; }
    public Guid BusketId { get; set; }

}
