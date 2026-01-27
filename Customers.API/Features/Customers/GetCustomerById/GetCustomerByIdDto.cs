using System;

namespace Customers.API.Features.Customers.GetCustomerById;

public record CustomerDetailsDto(
        Guid Id,
        string Name,
        Guid CustomerAddressId,
        DateOnly LastVisit,
        string GithubUserName
);