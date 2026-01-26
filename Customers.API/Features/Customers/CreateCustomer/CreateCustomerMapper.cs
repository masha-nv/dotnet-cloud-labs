

namespace Customers.API.Features.Customers.CreateCustomer;

public static class CreateCustomerMapper
{
    public static Models.Customer ToNewCustomer(this CreateCustomerDto customer, Models.CustomerAddress address)
    {
        return new Models.Customer { Id = Guid.NewGuid(), Address = address, Name = customer.Name, GithubUserName = customer.GithubUserName, LastVisit = DateOnly.FromDateTime(DateTime.Now) };
    }
}
