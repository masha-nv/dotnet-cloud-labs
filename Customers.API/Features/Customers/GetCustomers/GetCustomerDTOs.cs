namespace Customers.API.Features.Customer.GetCustomers;

public record GetCustomersDto(string? Query, int Page = 1, int PageSize = 3);

public record PagedCustomerSummaryDto(int TotalPages, IEnumerable<CustomerSummaryDto> Data);
public record CustomerSummaryDto(Guid Id, string Name, DateOnly LastVisit, string Country, string ImageUri, string LastUpdatedBy);

