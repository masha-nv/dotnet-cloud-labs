using Customers.API.Models;

namespace Customers.API.Features.Baskets.GetBasketById;

public record GetBasketDto(Guid Id, string CustomerName, IEnumerable<BasketItem> Items);
