using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblHauntedEvent
{
    public Guid Id { get; set; }

    public Guid HauntedLocationId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Description { get; set; } = null!;

    public string ImagePath { get; set; } = null!;
}
