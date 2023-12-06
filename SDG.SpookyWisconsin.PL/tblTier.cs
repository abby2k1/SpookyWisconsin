using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblTier
{
    public Guid Id { get; set; }

    public string TierName { get; set; } = null!;

    public int TierLevel { get; set; }
}
