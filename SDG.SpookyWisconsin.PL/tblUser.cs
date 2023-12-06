using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblUser
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
