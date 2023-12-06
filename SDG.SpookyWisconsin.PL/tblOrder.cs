using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblOrder
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public Guid UserId { get; set; }

    public DateTime ShipDate { get; set; }
}
