using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblNewsLetter
{
    public Guid Id { get; set; }

    public Guid HauntedEventId { get; set; }

    public string Description { get; set; } = null!;

    public DateOnly Date { get; set; }
}
