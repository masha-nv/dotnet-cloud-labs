

namespace Customers.API.Features.Customers.CreateCustomer;

public static class CreateCustomerMapper
{

    public static Models.Customer ToNewCustomer(this CreateCustomerDto customer, string imageUri)
    {
        return new Models.Customer
        {
            Name = customer.Name,
            GithubUserName = customer.GithubUserName,
            LastVisit = DateOnly.FromDateTime(DateTime.Now),
            CustomerAddressId = customer.CustomerAddressId,
            FileUri = imageUri
        };
    }
}
