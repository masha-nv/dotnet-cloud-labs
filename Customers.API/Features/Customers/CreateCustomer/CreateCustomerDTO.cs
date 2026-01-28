using System.ComponentModel.DataAnnotations;

namespace Customers.API.Features.Customers.CreateCustomer;

public record CreateCustomerDto(
    [StringLength(100, MinimumLength = 1)]
    string Name,

    [StringLength(100, MinimumLength = 1)]
    string GithubUserName,

    Guid CustomerAddressId
)
{
    public IFormFile? ImageFile { get; set; }
};

