
namespace Customers.API.Features.Customers.UpdateCustomer;

public static class UpdateCustomerMapper
{
    public static Models.Customer ToUpdatedCustomer(this UpdateCustomerDto customer, Models.CustomerAddress address, Guid id, string imageUri, string lastUpdatedBy)
    {
        return new Models.Customer
        {
            Id = id,
            Address = address,
            Name = customer.Name,
            GithubUserName = customer.GithubUserName,
            LastVisit = DateOnly.FromDateTime(DateTime.Now),
            FileUri = imageUri,
            LastUpdatedBy = lastUpdatedBy

        };
    }
}
