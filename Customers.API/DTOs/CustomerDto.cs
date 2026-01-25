using System.ComponentModel.DataAnnotations;

namespace Customers.API.DTOs;

public record CustomerDetailsDto(
        Guid Id,
        string Name,
        string Country,
        DateOnly LastVisit,

string GithubUserName

);

public record CustomerSummaryDto(Guid Id, string Name, DateOnly LastVisit, string Country);

public record CreateCustomerDto(
    [StringLength(10, MinimumLength = 1)]
    string Name,

    [StringLength(10, MinimumLength = 1)]
    string GithubUserName,

    Guid CustomerAddressId
);

public record UpdateCustomerDto(
    Guid Id,
    [StringLength(10, MinimumLength = 1)]
    string Name,

    [StringLength(10, MinimumLength = 1)]
    string GithubUserName,
    Guid CustomerAddressId);