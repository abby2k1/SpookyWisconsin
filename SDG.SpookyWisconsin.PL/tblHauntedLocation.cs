using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblHauntedLocation
{
    public Guid Id { get; set; }

    public Guid AddressId { get; set; }

    public string Name { get; set; } = null!;

    public string? ImagePath { get; set; }
}
