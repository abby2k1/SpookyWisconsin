using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblAddress
{
    public Guid Id { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string County { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZIP { get; set; } = null!;
}
