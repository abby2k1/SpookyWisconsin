using System;
using System.Collections.Generic;

namespace SDG.SpookyWisconsin.PL;

public partial class tblMember
{
    public Guid Id { get; set; }

    public Guid TierId { get; set; }

    public Guid NewsLetterId { get; set; }

    public string NewsLetterOpt { get; set; } = null!;

    public string MemberOpt { get; set; } = null!;
}
