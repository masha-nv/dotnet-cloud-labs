using System;
using Customers.API.DTOs;
using Customers.API.Models;

namespace Customers.API.Mappers;

public static class CustomerMappers
{
    public static CustomerDetailsDto ToCustomerDetailsDto(this Customer customer)
    {
        return new CustomerDetailsDto(
            customer.Id,
            customer.Name,
            customer.Address.Country,
            customer.LastVisit,
            customer.GithubUserName);
    }

    public static CustomerSummaryDto ToCustomerSummaryDto(this Customer customer)
    {
        return new CustomerSummaryDto(customer.Id, customer.Name, customer.LastVisit, customer.Address.Country);
    }

    public static Customer ToNewCustomer(this CreateCustomerDto customer, CustomerAddress address)
    {
        return new Customer { Id = Guid.NewGuid(), Address = address, Name = customer.Name, GithubUserName = customer.GithubUserName, LastVisit = DateOnly.FromDateTime(DateTime.Now) };
    }

    public static Customer ToUpdatedCustomer(this UpdateCustomerDto customer, CustomerAddress address)
    {
        return new Customer
        {
            Id = customer.Id,
            Address = address,
            Name = customer.Name,
            GithubUserName = customer.GithubUserName,
            LastVisit = DateOnly.FromDateTime(DateTime.Now)
        };
    }
}
