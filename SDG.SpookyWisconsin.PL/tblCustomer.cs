using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblCustomer
{
    public Guid Id { get; set; }

    public Guid MemberId { get; set; }

    public Guid UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public Guid AddressId { get; set; }

    public string Email { get; set; } = null!;
}
