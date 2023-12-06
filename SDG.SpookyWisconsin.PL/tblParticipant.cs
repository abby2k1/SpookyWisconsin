using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblParticipant
{
    public Guid Id { get; set; }

    public Guid HauntedEventId { get; set; }

    public Guid CustomerId { get; set; }
}
