namespace Customers.API.Features.Baskets.GetBaskets;

public record GetBasketsItemDto(int Quantity);
public record class GetBasketsDto(Guid Id, string CustomerName, IEnumerable<GetBasketsItemDto> Items);

