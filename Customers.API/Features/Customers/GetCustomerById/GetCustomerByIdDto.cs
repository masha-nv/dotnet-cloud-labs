using System;

namespace Customers.API.Features.Customers.GetCustomerById;

public record CustomerDetailsDto(
        Guid Id,
        string Name,
        string Country,
        DateOnly LastVisit,
        string GithubUserName
);