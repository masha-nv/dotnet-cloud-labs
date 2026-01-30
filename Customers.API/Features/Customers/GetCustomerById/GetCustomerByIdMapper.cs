using System;

namespace Customers.API.Features.Customers.GetCustomerById;

public static class GetCustomerByIdMapper
{
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
