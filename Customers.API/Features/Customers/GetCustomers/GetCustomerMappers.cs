
using Customers.API.Features.Customer.GetCustomers;

namespace Customers.API.Features.Customers.GetCustomers;

public static class GetCustomerMappers
{
    public static CustomerSummaryDto ToCustomerSummaryDto(this Models.Customer customer)
    {
        return new CustomerSummaryDto(customer.Id, customer.Name, customer.LastVisit, customer.Address!.Country);
    }
}
