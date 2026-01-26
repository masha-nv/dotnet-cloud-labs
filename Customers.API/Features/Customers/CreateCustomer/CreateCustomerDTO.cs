using System.ComponentModel.DataAnnotations;

namespace Customers.API.Features.Customers.CreateCustomer;

public record CreateCustomerDto(
    [StringLength(10, MinimumLength = 1)]
    string Name,

    [StringLength(10, MinimumLength = 1)]
    string GithubUserName,

    Guid CustomerAddressId
);
