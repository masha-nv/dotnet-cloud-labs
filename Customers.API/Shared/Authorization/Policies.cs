using System;

namespace Customers.API.Shared.Authorization;

public class Policies
{
    public const string AdminPolicy = nameof(AdminPolicy);
    public const string UserPolicy = nameof(UserPolicy);
}
