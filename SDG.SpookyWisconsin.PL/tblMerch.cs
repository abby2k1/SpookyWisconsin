using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblMerch
{
    public Guid Id { get; set; }

    public string MerchName { get; set; } = null!;

    public int InStkQty { get; set; }

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public string ImagePath { get; set; } = null!;
}
