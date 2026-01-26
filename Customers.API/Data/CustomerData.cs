using Customers.API.Features.Customer.GetCustomers;
using Customers.API.Features.Customers.CreateCustomer;
using Customers.API.Features.Customers.GetCustomerById;
using Customers.API.Features.Customers.UpdateCustomer;
using Customers.API.Models;
using Customers.API.Features.Customers.GetCustomers;
using Customers.API.Features.Customers.GetCustomerById;

namespace Customers.API.Data;

public class CustomerData
{
    private readonly List<CustomerAddress> addresses = [new CustomerAddress { Country = "USA", State = "CA", Id = Guid.NewGuid() }];
    private readonly List<Customer> customers;

    public CustomerData()
    {
        customers = [
            new Customer {
            GithubUserName = "mashadev",
            Name = "Masha",
            Id = Guid.NewGuid(),
            Address = addresses[0],
            LastVisit = new DateOnly(2026, 01, 25),
            CustomerAddressId = addresses[0].Id }
        ];
    }

    public IEnumerable<CustomerSummaryDto> GetCustomers()
    {
        return customers.Select(c => c.ToCustomerSummaryDto());
    }
    public IEnumerable<CustomerAddress> GetCustomerAddresses() => addresses;

    public CustomerDetailsDto? GetCustomer(Guid id)
    {
        var customer = customers.Find(c => c.Id == id) ?? throw new Exception("Customer with this id is not found");
        return customer.ToCustomerDetailsDto();
    }

    public CustomerDetailsDto CreateCustomer(CreateCustomerDto customer)
    {
        var address = addresses.Find(a => a.Id == customer.CustomerAddressId);
        Customer c = customer.ToNewCustomer(address!);
        customers.Add(c);
        return c.ToCustomerDetailsDto();
    }

    public void UpdateCustomer(Guid id, UpdateCustomerDto updatedCustomer)
    {
        var idx = customers.FindIndex(c => c.Id == id);
        if (idx == -1)
        {
            throw new Exception("Customer not found");
        }
        Customer customer = customers[idx];
        var address = addresses.Find(a => a.Id == customer.CustomerAddressId);
        Customer updated = updatedCustomer.ToUpdatedCustomer(address!, id);
        customers[idx] = updated;
    }

    public void DeleteCustomer(Guid id)
    {
        customers.RemoveAll(c => c.Id == id);
    }

    public CustomerAddress? GetCustomerAddress(Customer customer)
    {
        var addressId = customer.CustomerAddressId;
        return addresses.Find(a => a.Id == addressId);
    }
}
