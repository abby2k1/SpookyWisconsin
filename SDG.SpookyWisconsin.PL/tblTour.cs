using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblTour
{
    public Guid Id { get; set; }

    public Guid HauntedLocationId { get; set; }

    public string TourName { get; set; } = null!;

    public string Description { get; set; } = null!;
}
