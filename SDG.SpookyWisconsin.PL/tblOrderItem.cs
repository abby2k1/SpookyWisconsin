using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblOrderItem
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid MerchId { get; set; }

    public int Quantity { get; set; }

    public decimal Cost { get; set; }
}
