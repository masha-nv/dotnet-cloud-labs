namespace Customers.API.Features.Customer.GetCustomers;

public record CustomerSummaryDto(Guid Id, string Name, DateOnly LastVisit, string Country);

