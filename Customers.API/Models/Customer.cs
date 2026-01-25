using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.API.Models;

public class Customer
{
    public required string Name { get; set; }

    public required string GithubUserName { get; set; }

    [Key]
    public Guid Id { get; set; }

    [ForeignKey("CustomerAddress")]
    public Guid CustomerAddressId { get; set; }

    public required CustomerAddress Address { get; set; }
    public required DateOnly LastVisit { get; set; }
}
