

namespace Customers.API.Features.Customers.CreateCustomer;

public static class CreateCustomerMapper
{

    public static Models.Customer ToNewCustomer(this CreateCustomerDto customer, string imageUri, string lastUpdatedBy)
    {
        return new Models.Customer
        {
            Name = customer.Name,
            GithubUserName = customer.GithubUserName,
            LastVisit = DateOnly.FromDateTime(DateTime.Now),
            CustomerAddressId = customer.CustomerAddressId,
            FileUri = imageUri,
            LastUpdatedBy = lastUpdatedBy
        };
    }

    public static CustomerDetailsDto ToCustomerDetailsDto(this Models.Customer customer)
    {
        return new CustomerDetailsDto(
            customer.Id,
            customer.Name,
            customer.CustomerAddressId,
            customer.LastVisit,
            customer.GithubUserName,
            customer.FileUri,
            customer.LastUpdatedBy
            );
    }
}
