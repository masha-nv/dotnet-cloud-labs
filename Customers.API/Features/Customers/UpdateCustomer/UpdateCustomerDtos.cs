using System.ComponentModel.DataAnnotations;

namespace Customers.API.Features.Customers.UpdateCustomer;

public record UpdateCustomerDto(
    Guid Id,
    [StringLength(10, MinimumLength = 1)]
    string Name,

    [StringLength(10, MinimumLength = 1)]
    string GithubUserName,
    Guid CustomerAddressId)

{
    public IFormFile? ImageFile { get; set; }
};